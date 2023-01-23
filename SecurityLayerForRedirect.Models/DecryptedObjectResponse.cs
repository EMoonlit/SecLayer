namespace SecurityLayerForRedirect.Models;

public class DecryptedObjectResponse
{
    private BaseResponse Response { get; set; }
    private string DecryptedObject { get; set; }

    public DecryptedObjectResponse(BaseResponse response, string decryptedObject)
    {
        Response = response;
        DecryptedObject = decryptedObject;
    }
}