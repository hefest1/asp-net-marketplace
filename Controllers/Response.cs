using System.Net;

namespace Controllers;

public sealed class Response
{
    public string Message;
    public HttpStatusCode StatusCode;
    public object Payload;

    public Response (string message, HttpStatusCode statusCode, object payload)
    {
        Message = message;
        StatusCode = statusCode;
        Payload = payload;
    }
}