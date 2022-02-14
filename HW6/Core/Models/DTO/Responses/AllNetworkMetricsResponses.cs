using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models.DTO.Responses
{
    public class AllNetworkMetricsResponses
    {
        [JsonPropertyName("NetworkMetrics")]
        public List<NetworkMetricDto> NetworkMetrics { get; set; }

        public AllNetworkMetricsResponses()
        {

        }
    }
}
