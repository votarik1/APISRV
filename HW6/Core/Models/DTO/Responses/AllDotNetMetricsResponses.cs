using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models.DTO.Responses
{
    public class AllDotNetMetricsResponses
    {
        [JsonPropertyName("DotNetMetrics")]
        public List<DotNetMetricDto> DotNetMetrics { get; set; }

        public AllDotNetMetricsResponses()
        {

        }
    }
}
