using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models.DTO.Responses
{
    public class AllHddMetricsResponses
    {
        [JsonPropertyName("HddMetrics")]
        public List<HddMetricDto> HddMetrics { get; set; }

        public AllHddMetricsResponses()
        {

        }
    }
}
