using System.Security.Cryptography;
using System.Text;

namespace SecurityLayerForRedirect.Services;

public class DecryptService
{
    private readonly RSACryptoServiceProvider _csp;
    private readonly RSAParameters _privateKey;

    public DecryptService(RSACryptoServiceProvider csp, RSAParameters privateKey)
    {
        _csp = csp;
        _privateKey = privateKey;
    }

    public string Decrypt(string cypherText)
    {
        var dataBytes = Convert.FromBase64String(cypherText);

        // _csp.ImportRSAPrivateKey(_privateKey, out _);

        var plainText = _csp.Decrypt(dataBytes, false);
        return Encoding.Unicode.GetString(plainText);
    }
}