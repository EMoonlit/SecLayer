using SecurityLayerForRedirect.Models.UI;

namespace SecurityLayerForRedirect.Tests.Setup;

public static class ApiSettingsSetup
{
    public static void SetFakeApiSettingsInfo(ApiSettings apiSettings)
    {
        apiSettings.Key = "NHQ3dyF6JUMqRi1KYU5kUmdVa1hwMnM1dTh4L0E/RCg=";
        apiSettings.KeySize = 16;
    }
}