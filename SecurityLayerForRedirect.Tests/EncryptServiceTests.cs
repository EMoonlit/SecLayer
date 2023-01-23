using System.Security.Cryptography;
using SecurityLayerForRedirect.Services;
using Xunit;

namespace SecurityLayerForRedirect.Tests;

public class UnitTest1
{
    private static readonly RSACryptoServiceProvider _csp = new(2048);
    private readonly RSAParameters _publicKey = _csp.ExportParameters(false);
    private readonly RSAParameters _privateKey = _csp.ExportParameters(true);
    
    [Fact]
    public void ShouldEncryptAndDecrypt()
    {
        const string textToEncrypt = "text to encrypt";
        var csp = new RSACryptoServiceProvider(2048);
        var encrypt = new EncryptService(csp, _publicKey);
        var decrypt = new DecryptService(csp, _privateKey);
        var result = encrypt.Encrypt(textToEncrypt);
        Assert.Equal(decrypt.Decrypt(result), textToEncrypt);
    }
}