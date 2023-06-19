using System.Security.Cryptography;
using System.Text;
using SecurityLayerForRedirect.Models.UI;
using SecurityLayerForRedirect.Services.Interfaces;

namespace SecurityLayerForRedirect.Services;

public class CryptService : ICryptService
{
    private readonly string _key;
    private readonly int _keySize;

    public CryptService(ApiSettings apiSettings)
    {
        _key = apiSettings.Key;
        _keySize = apiSettings.KeySize;
    }
    
    public string Decrypt(string cypherText)
    {
        var dataBytes = Convert.FromBase64String(cypherText);

        var aes = makeAes();

        var decryptedText = aes.DecryptCbc(dataBytes, aes.IV);
        
        return Encoding.UTF8.GetString(decryptedText);
    }

    public string Encrypt(string plainText)
    {
        byte[] playTextBytes = Encoding.UTF8.GetBytes(plainText);

        var aes = makeAes();

        var cypher = aes.EncryptCbc(playTextBytes, aes.IV);
        
        return Convert.ToBase64String(cypher);
    }

    private Aes makeAes()
    {
        var key = Convert.FromBase64String(_key);
        byte[] iv = new byte[_keySize];

        Aes aes = Aes.Create();
        aes.Key = key;
        aes.IV = iv;

        return aes;
    }
}