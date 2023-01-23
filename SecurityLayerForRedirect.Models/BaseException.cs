using System.Net;
using System.Runtime.Serialization;

namespace SecurityLayerForRedirect.Models;

[Serializable]
public class BaseException : Exception
{
    private HttpStatusCode StatusCode { get; set; }

    public BaseException()
    {
    }

    public BaseException(string message)
        : base(message)
    {
    }

    public BaseException(string message, HttpStatusCode statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }

    public BaseException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public BaseException(string message, Exception innerException, HttpStatusCode statusCode)
        : base(message, innerException)
    {
        StatusCode = statusCode;
    }

    protected BaseException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}