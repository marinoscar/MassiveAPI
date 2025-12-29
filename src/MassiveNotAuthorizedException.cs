namespace MassiveAPI;

/// <summary>
/// Represents an authorization failure returned by the Massive API.
/// </summary>
public sealed class MassiveNotAuthorizedException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MassiveNotAuthorizedException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="requestId">The request identifier returned by the API.</param>
    public MassiveNotAuthorizedException(string message, string? requestId)
        : base(message)
    {
        RequestId = requestId;
    }

    /// <summary>
    /// Gets the request identifier returned by the API.
    /// </summary>
    public string? RequestId { get; }
}
