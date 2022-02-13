using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.DTO.Responses
{
    public class AllNetworkMetricsResponses
    {
        public List<NetworkMetricDto> NetworkMetrics { get; set; }

        public AllNetworkMetricsResponses()
        {

        }
    }
}
