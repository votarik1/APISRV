using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Responses
{
    public class AllNetworkMetricsResponses
    {
        public List<NetworkMetricDto> NetworkMetrics { get; set; }
    }
}
