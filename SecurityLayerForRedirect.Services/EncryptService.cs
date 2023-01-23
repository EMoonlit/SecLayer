using System.Security.Cryptography;
using System.Text;

namespace SecurityLayerForRedirect.Services;

public class EncryptService
{
    private readonly RSACryptoServiceProvider _csp;
    private readonly string _publicKey;

    public EncryptService(RSACryptoServiceProvider csp, string publicKey)
    {
        _csp = csp;
        _publicKey = publicKey;
    }

    public string Encrypt(string plainText)
    {
        // RSA rsa = RSA.Create();
        // var test = PemEncoding.Find(_publicKey.ToString());
        // rsa.ImportFromPem();
        // _csp.ImportParameters(_publicKey);
        // _csp.ImportRSAPublicKey(new ReadOnlySpan<byte>(_publicKey), out _);
        // _csp.ImportSubjectPublicKeyInfo(_publicKey, out _);
        // _csp.ImportCspBlob(_publicKey);
        _csp.ImportFromPem(_publicKey);
        var data = Encoding.Unicode.GetBytes(plainText);
        
        var cypher = _csp.Encrypt(data, false);
        return Convert.ToBase64String(cypher);
        // return cypher;
    }
}