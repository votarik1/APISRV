using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.DTO.Responses
{
    public class AllRamMetricsResponses
    {
        public List<RamMetricDto> RamMetrics { get; set; }

        public AllRamMetricsResponses()
        {

        }
    }
}
