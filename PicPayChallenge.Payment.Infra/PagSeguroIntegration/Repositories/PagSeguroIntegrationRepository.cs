using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using PicPayChallenge.Common.Exceptions;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Entities;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories;
using PicPayChallenge.Payment.Domain.PagSeguroIntegration.Repositories.Responses;

namespace PicPayChallenge.Payment.Infra.PagSeguroIntegration.Repositories
{
    public class PagSeguroIntegrationRepository : IPagSeguroIntegrationRepository
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<PagSeguroIntegrationRepository> logger;

        public PagSeguroIntegrationRepository(IHttpClientFactory httpClientFactory, ILogger<PagSeguroIntegrationRepository> logger)
        {
            this.httpClient = httpClientFactory.CreateClient("PagSeguro.Api");
            this.httpClient.Timeout = TimeSpan.FromMinutes(10);
            this.logger = logger;
        }
        public ChargeResponse CreateCharge(Charge charge)
        {
            const string ENDPOINT_URL = "charges";
            var body = JsonSerializer.Serialize(charge);

            StringContent content = new StringContent(body, Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(httpClient.BaseAddress + ENDPOINT_URL, content).Result;

            if (!response.IsSuccessStatusCode)
            {
                this.logger.LogError("Erro processar pagamento PagSeguro");
                throw new BadRequestException();
            }

            string jsonResponse = response.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<ChargeResponse>(jsonResponse);
        }
    }
}
