using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PicPayChallenge.Payment.Ioc.Extensions
{
    public static class ConfigureHttp
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("PagSeguro.Api", httpClient =>
            {
                var url = configuration.GetSection("PagSeguroApi:BaseUrl").Value;
                var token = configuration.GetSection("PagSeguroApi:Token").Value;

                httpClient.BaseAddress = new Uri(url);
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                httpClient.DefaultRequestHeaders.Add("User-Agent", AppDomain.CurrentDomain.FriendlyName);
            });
        }
    }
}