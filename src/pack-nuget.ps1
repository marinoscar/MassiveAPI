#Information to publish the nuget packages
$nugetExePath = "C:\git\nuget\nuget.exe"  # Path to nuget.exe
$apiKeyFilePath = "C:\git\nuget\apikey.txt"  # Path to the file containing your NuGet API key
$source = "https://api.nuget.org/v3/index.json"  # NuGet source URL

# Ensure the API key file exists
if (-Not (Test-Path $apiKeyFilePath)) {
    Write-Error "API key file not found at $apiKeyFilePath"
    exit 1
}

# Read the API key from the file
$apiKey = Get-Content -Path $apiKeyFilePath -Raw
if ([string]::IsNullOrWhiteSpace($apiKey)) {
    Write-Error "API key is empty or invalid"
    exit 1
}

# Get all .csproj files in the current directory and subdirectories
$csprojFiles = Get-ChildItem -Path . -Filter *.csproj -Recurse

foreach ($csprojFile in $csprojFiles) {
    try {
        # Load the project file as XML
        [xml]$projectFile = Get-Content $csprojFile.FullName

        # Ensure the <Project> root element exists
        if (-not $projectFile.Project) {
            Write-Error "Invalid .csproj file structure in $($csprojFile.FullName). Could not find the <Project> root element."
            continue
        }

        # Check for namespaces and handle accordingly
        $namespaceManager = $null
        if ($projectFile.DocumentElement.NamespaceURI -ne "") {
            $namespaceManager = New-Object System.Xml.XmlNamespaceManager($projectFile.NameTable)
            $namespaceManager.AddNamespace("ns", $projectFile.DocumentElement.NamespaceURI)
        }

        # Locate or create the <PropertyGroup> node
        $propertyGroup = $projectFile.Project.PropertyGroup
        if (-not $propertyGroup) {
            Write-Host "No <PropertyGroup> element found in $($csprojFile.Name). Creating a new one..."
            $propertyGroup = $projectFile.CreateElement("PropertyGroup")
            $projectFile.Project.AppendChild($propertyGroup) | Out-Null
        }

        # Locate or create the <Version> node
        if ($namespaceManager) {
            $versionNode = $propertyGroup.SelectSingleNode("ns:Version", $namespaceManager)
        } else {
            $versionNode = $propertyGroup.SelectSingleNode("Version")
        }

        if (-not $versionNode) {
            Write-Host "No <Version> element found in $($csprojFile.Name). Adding a default version..."
            $versionNode = $projectFile.CreateElement("Version", $projectFile.DocumentElement.NamespaceURI)
            $versionNode.InnerText = "1.0.0"  # Default version
            $propertyGroup.AppendChild($versionNode) | Out-Null
        }

        # Increment version
        try {
            $currentVersion = [Version]$versionNode.InnerText
        } catch {
            Write-Warning "Invalid version format detected in $($csprojFile.Name). Resetting to 1.0.0."
            $currentVersion = [Version]"1.0.0"
        }

        $newVersion = "$($currentVersion.Major).$($currentVersion.Minor).$($currentVersion.Build + 1)"
        $versionNode.InnerText = $newVersion

        # Save the updated .csproj file
        $projectFile.Save($csprojFile.FullName)
        Write-Host "Updated version to $newVersion in $($csprojFile.Name)."

        # Check if PackageProjectUrl exists
        if ($namespaceManager) {
            $packageProjectUrlNode = $propertyGroup.SelectSingleNode("ns:PackageProjectUrl", $namespaceManager)
        } else {
            $packageProjectUrlNode = $propertyGroup.SelectSingleNode("PackageProjectUrl")
        }

        if ($packageProjectUrlNode -and $packageProjectUrlNode.InnerText) {
            Write-Host "Project $($csprojFile.Name) has PackageProjectUrl. Building in Release mode and packing..."

            # Build and pack the project
            $projectDirectory = $csprojFile.DirectoryName
            Set-Location $projectDirectory
            dotnet build -c Release
            if ($LASTEXITCODE -eq 0) {
                dotnet pack -c Release
                if ($LASTEXITCODE -eq 0) {
                    Write-Host "Build and pack completed successfully for $($csprojFile.Name)."
					# Publishing the nuget package
					# Find the generated .nupkg file
					Write-Output "Looking for packages to publish at $($projectDirectory)"
					$nupkgFile = Get-ChildItem -Path $projectDirectory -Filter *.nupkg -Recurse | Sort-Object LastWriteTime -Descending | Select-Object -First 1
					if (-Not $nupkgFile) {
						Write-Error "No .nupkg file found in $($projectDirectory)"
						exit 1
					}
					# Push the package to NuGet
					& $nugetExePath push $nupkgFile.FullName -ApiKey $apiKey -Source $source
					Write-Output "NuGet package published successfully."
					
					# Find the generated .snupkg symbos file
					$nupkgSymFile = Get-ChildItem -Path $projectDirectory -Filter *.snupkg -Recurse | Sort-Object LastWriteTime -Descending | Select-Object -First 1
					if (-Not $nupkgFile) {
						Write-Warning "No .nupkg file found in $($projectDirectory)"
					}
					else{
						# Push the package to Symbos NuGet
						& $nugetExePath push $nupkgSymFile.FullName -ApiKey $apiKey -Source $source
						Write-Output "NuGet Symbos package published successfully."
					}
					
                } else {
                    Write-Error "Pack failed for $($csprojFile.Name). Please check the logs for details."
                }
            } else {
                Write-Error "Build failed for $($csprojFile.Name). Please check the logs for details."
            }
            Set-Location -Path ..
        } else {
            Write-Host "Project $($csprojFile.Name) does not have a PackageProjectUrl, skipping."
        }
    } catch {
        Write-Error "An error occurred while processing $($csprojFile.FullName): $_"
    }
}