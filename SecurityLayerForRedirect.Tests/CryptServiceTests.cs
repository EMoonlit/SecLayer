using NSubstitute;
using SecurityLayerForRedirect.Models.UI;
using SecurityLayerForRedirect.Services;
using SecurityLayerForRedirect.Services.Interfaces;
using SecurityLayerForRedirect.Tests.Setup;
using Xunit;

namespace SecurityLayerForRedirect.Tests;

public class CryptServiceTests
{
    private const string TEXT_TO_ENCRYPT = "Hello, world!";
    private const string TEXT_ENCRYPTED = "4sozh7BaQQ5Hpsht8I33cg==";
    private readonly ApiSettings _apiSettings;
    private readonly ICryptService _cryptService;

    public CryptServiceTests()
    {
        _apiSettings = Substitute.For<ApiSettings>();
        ApiSettingsSetup.SetFakeApiSettingsInfo(_apiSettings);
        _cryptService = new CryptService(_apiSettings);
    }

    [Fact]
    public void ShouldEncryptText()
    {
        var encryptedText = _cryptService.Encrypt(TEXT_TO_ENCRYPT);
        Assert.Equal(TEXT_ENCRYPTED, encryptedText);
    }

    [Fact]
    public void ShouldDecryptText()
    {
        var decryptedText = _cryptService.Decrypt(TEXT_ENCRYPTED);
        Assert.Equal(TEXT_TO_ENCRYPT, decryptedText);
    }
}