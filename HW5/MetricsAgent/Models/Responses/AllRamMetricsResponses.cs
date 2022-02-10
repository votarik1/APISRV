using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Responses
{
    public class AllRamMetricsResponses
    {
        public List<RamMetricDto> RamMetrics { get; set; }
    }
}
