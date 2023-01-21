using Newtonsoft.Json;

namespace SecurityLayerForRedirect.Models;

public class TrackingApiResponse
{
    [JsonProperty("url")]
    private Uri uri { get; set; }
}