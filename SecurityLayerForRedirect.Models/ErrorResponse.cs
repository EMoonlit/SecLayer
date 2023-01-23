using System.Net;
using Newtonsoft.Json;

namespace SecurityLayerForRedirect.Models;

public class ErrorResponse
{
    ///<summary>
    /// Error message text
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }

    ///<summary>
    /// Status code
    /// </summary>
    [JsonProperty("statusCode")]
    public int StatusCode { get; set; }

    public ErrorResponse(string message)
    {
        Message = message;
    }

    public ErrorResponse(string message, HttpStatusCode statusCode)
    {
        Message = message;
        StatusCode = (int)statusCode;
    }
}