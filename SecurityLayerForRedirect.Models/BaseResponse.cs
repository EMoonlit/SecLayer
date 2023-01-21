namespace SecurityLayerForRedirect.Models;

public class BaseResponse
{
    private string Message { get; set; }
    private bool Success { get; set; }

    public BaseResponse(string message, bool success)
    {
        Message = message;
        Success = success;
    }
}