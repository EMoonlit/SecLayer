namespace SecurityLayerForRedirect.Models;

public class EncryptedObjectResponse
{
    private BaseResponse Response { get; set; }
    private string EncryptedObject { get; set; }

    public EncryptedObjectResponse(BaseResponse response, string encryptedObject)
    {
        Response = response;
        EncryptedObject = encryptedObject;
    }
}