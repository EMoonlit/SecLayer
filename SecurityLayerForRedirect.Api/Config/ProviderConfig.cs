using SecurityLayerForRedirect.Models.UI;
using SecurityLayerForRedirect.Services;
using SecurityLayerForRedirect.Services.Interfaces;

namespace SecurityLayerForRedirect.Api.Config;

public static class ProviderConfig
{
    public static void AddProviderConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        var settings = configuration.GetSection("Settings").Get<ApiSettings>();


        services.AddSingleton(settings)
            .AddSingleton<ICryptService, CryptService>();
    }
}