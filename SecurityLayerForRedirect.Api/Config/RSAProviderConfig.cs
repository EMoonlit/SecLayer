using System.Security.Cryptography;
using SecurityLayerForRedirect.Services;

namespace SecurityLayerForRedirect.Api.Config;

public static class RSAProviderConfig
{
    public static void AddRSAProviderConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        byte[] PublicKey = Convert.FromBase64String(configuration["Settings:PublicKey"]);
        byte[] PrivateKey = Convert.FromBase64String(configuration["Settings:PrivateKey"]);
        
        var csp = new RSACryptoServiceProvider(2048);

        // PemEncoding.Find(PublicKey.ToString());
        var privateKey = csp.ExportParameters(true);
        privateKey.Modulus = PrivateKey;
        //
        var publicKey = csp.ExportParameters(false);
        publicKey.Modulus = PublicKey;
        
        
        var descryptor = new DecryptService(csp, privateKey);
        var encryptor = new EncryptService(csp, publicKey);

        var teste1 = encryptor.Encrypt("batata");
        Console.WriteLine(teste1);
        var teste2 = descryptor.Decrypt(teste1);
        Console.WriteLine(teste2);
    }
}