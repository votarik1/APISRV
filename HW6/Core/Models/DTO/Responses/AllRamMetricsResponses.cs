using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models.DTO.Responses
{
    public class AllRamMetricsResponses
    {
        [JsonPropertyName("RamMetrics")]
        public List<RamMetricDto> RamMetrics { get; set; }

        public AllRamMetricsResponses()
        {

        }
    }
}
