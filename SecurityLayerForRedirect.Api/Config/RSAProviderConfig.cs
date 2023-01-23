using System.Security.Cryptography;
using System.Text;
using SecurityLayerForRedirect.Services;

namespace SecurityLayerForRedirect.Api.Config;

public static class RSAProviderConfig
{
    public static void AddRSAProviderConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        byte[] PublicKey = Convert.FromBase64String(configuration["Settings:PublicKeyOrigin"]);
        byte[] PrivateKey = Convert.FromBase64String(configuration["Settings:PrivateKeyOrigin"]);
        var publicKeyData = Encoding.UTF8.GetString(PublicKey);
        var privateKeyData = Encoding.UTF8.GetString(PrivateKey);
        var csp = new RSACryptoServiceProvider(2048);

        // PemEncoding.Find(PublicKey.ToString());
        // var privateKey = csp.ExportParameters(true);
        // privateKey.Modulus = PrivateKey;
        // //
        // var publicKey = csp.ExportParameters(false);
        // publicKey.Modulus = PublicKey;
        
        
        var descryptor = new DecryptService(csp, privateKeyData);
        var encryptor = new EncryptService(csp, publicKeyData);

        var teste1 = encryptor.Encrypt("batata");
        Console.WriteLine(teste1);
        var teste2 = descryptor.Decrypt(teste1);
        Console.WriteLine(teste2);
    }
}