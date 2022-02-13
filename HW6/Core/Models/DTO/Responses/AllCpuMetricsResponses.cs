using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.DTO.Responses
{
    public class AllCpuMetricsResponses
    {
        public List<CpuMetricDto> CpuMetrics { get; set; }

        public AllCpuMetricsResponses()
        {

        }
    }
}
