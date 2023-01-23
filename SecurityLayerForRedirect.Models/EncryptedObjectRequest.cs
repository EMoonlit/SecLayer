namespace SecurityLayerForRedirect.Models;

public class EncryptedObjectRequest
{
    public Uri Uri  { get; set; }
    public string Action { get; set; }
    public string Option { get; set; }
}