using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Models.DTO.Responses
{
    public class AllCpuMetricsResponses
    {
        [JsonPropertyName("CpuMetrics")]
        public List<CpuMetricDto> CpuMetrics { get; set; }

        public AllCpuMetricsResponses()
        {

        }
    }
}
