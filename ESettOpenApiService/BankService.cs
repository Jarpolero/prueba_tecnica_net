using ESettOpenApiInterfaces.Interfaces;
using ESettOpenApiInterfaces.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ESettOpenApiService
{
    public class BankService : IBankService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<BankService> _logger;

        public BankService(HttpClient httpClient, IConfiguration configuration, ILogger<BankService> logger)
        {
            if (logger == null)
            {
                throw new ApplicationException("Critical configuration failed.");
            }
            _logger = logger;
            if (httpClient == null)
            {
                _logger.LogError("HttpClient not initilized");
                throw new ApplicationException("Critical configuration failed.");
            }
            if (configuration == null)
            {
                _logger.LogError("Configuration not initilized");
                throw new ApplicationException("Critical configuration failed.");
            }
            _httpClient = httpClient;
            _configuration = configuration;

            var baseUrl = _configuration["ApiBaseUrl"];
            if (string.IsNullOrEmpty(baseUrl))
            {
                _logger.LogError("ApiBaseUrl not found");
                throw new ArgumentNullException("La configuración de la URL base de la API de Esett no se encontró en el archivo de configuración.");
            }

            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<IEnumerable<BankApi>?> GetBanks()
        {
            var response = await _httpClient.GetAsync("EXP06/Banks");
            response.EnsureSuccessStatusCode();
            var result = JsonConvert.DeserializeObject<IEnumerable<BankApi>>(await response.Content.ReadAsStringAsync());
            return result;
        }
    }
}
