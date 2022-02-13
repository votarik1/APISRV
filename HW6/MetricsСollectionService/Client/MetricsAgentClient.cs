using Core.Models.DTO.Request;
using Core.Models.DTO.Responses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetricsManager.Client
{
    public class MetricsAgentClient : IMetricsAgentClient
    {
        private readonly ILogger<MetricsAgentClient> _logger;
        private readonly HttpClient _httpClient;
        private readonly string _urlBase;

        public MetricsAgentClient(HttpClient httpClient, IConfiguration configuration, ILogger<MetricsAgentClient> logger)
        {
            _httpClient = httpClient;
            _urlBase = configuration.GetValue<string>("AgentBaseUrl");
            _logger = logger;
        }

        public AllCpuMetricsResponses GetAllCpuMetrics(AllCpuMetricsRequest request)
        {

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_urlBase}/api/metrics/cpu/from/{request.From}/to/{request.To}");
           // requestMessage.Headers.Add("Acept", "application/vnd.github.v3+json");
            HttpResponseMessage responseMessage = _httpClient.Send(requestMessage);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseStream = responseMessage.Content.ReadAsStreamAsync().Result;
                var metricsResponse = JsonSerializer.DeserializeAsync<AllCpuMetricsResponses>(responseStream).Result;
                return metricsResponse;
            }
            _logger.LogError(responseMessage.ReasonPhrase);
            return null; 
        }

        public AllNetworkMetricsResponses GetAllNetworkMetrics(AllNetworkMetricsRequest request)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_urlBase}/api/metrics/network/from/{request.From}/to/{request.To}");
            //requestMessage.Headers.Add("Acept", "application/vnd.github.v3+json");
            HttpResponseMessage responseMessage = _httpClient.Send(requestMessage);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseStream = responseMessage.Content.ReadAsStreamAsync().Result;
                var metricsResponse = JsonSerializer.DeserializeAsync<AllNetworkMetricsResponses>(responseStream).Result;
                return metricsResponse;
            }
            _logger.LogError(responseMessage.ReasonPhrase);
            return null;
        }

        public AllRamMetricsResponses GetAllRamMetrics(AllRamMetricsRequest request)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_urlBase}/api/metrics/ram/from/{request.From}/to/{request.To}");
            //requestMessage.Headers.Add("Acept", "application/vnd.github.v3+json");
            HttpResponseMessage responseMessage = _httpClient.Send(requestMessage);
            if (responseMessage.IsSuccessStatusCode)
            {
                using var responseStream = responseMessage.Content.ReadAsStreamAsync().Result;
                var metricsResponse = JsonSerializer.DeserializeAsync<AllRamMetricsResponses>(responseStream).Result;
                return metricsResponse;
            }
            _logger.LogError(responseMessage.ReasonPhrase);
            return null;
        }

        public AllHddMetricsResponses GetAllHddMetrics(AllHddMetricsRequest request)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_urlBase}/api/metrics/hdd/from/{request.From}/to/{request.To}");
            //requestMessage.Headers.Add("Acept", "application/vnd.github.v3+json");
            HttpResponseMessage responseMessage = _httpClient.Send(requestMessage);
            if (responseMessage.IsSuccessStatusCode)
            {
                using var responseStream = responseMessage.Content.ReadAsStreamAsync().Result;
                var metricsResponse = JsonSerializer.DeserializeAsync<AllHddMetricsResponses>(responseStream).Result;
                return metricsResponse;
            }
            _logger.LogError(responseMessage.ReasonPhrase);
            return null;
        }

        public AllDotNetMetricsResponses GetAllDotNetMetrics(AllDotNetMetricsRequest request)
        {
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_urlBase}/api/metrics/dotnet/from/{request.From}/to/{request.To}");
            //requestMessage.Headers.Add("Acept", "application/vnd.github.v3+json");
            HttpResponseMessage responseMessage = _httpClient.Send(requestMessage);
            if (responseMessage.IsSuccessStatusCode)
            {
                using var responseStream = responseMessage.Content.ReadAsStreamAsync().Result;
                var metricsResponse = JsonSerializer.DeserializeAsync<AllDotNetMetricsResponses>(responseStream).Result;
                return metricsResponse;
            }
            _logger.LogError(responseMessage.ReasonPhrase);
            return null;
        }
    }
}
