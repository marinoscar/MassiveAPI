using System.Net;

namespace MassiveAPI.UnitTests;

public sealed class TestHttpMessageHandler : HttpMessageHandler
{
    private readonly HttpResponseMessage _response;

    public TestHttpMessageHandler(HttpResponseMessage response)
    {
        _response = response;
    }

    public HttpRequestMessage? LastRequest { get; private set; }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        LastRequest = request;
        return Task.FromResult(_response);
    }

    public static HttpResponseMessage CreateJsonResponse(string json, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(json)
        };
    }
}
