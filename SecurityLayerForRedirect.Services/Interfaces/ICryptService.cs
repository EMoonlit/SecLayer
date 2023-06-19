namespace SecurityLayerForRedirect.Services.Interfaces;

public interface ICryptService
{
    string Decrypt(string cypherText);
    string Encrypt(string cypherText);
}