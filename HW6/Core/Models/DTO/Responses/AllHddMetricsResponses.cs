using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models.DTO.Responses
{
    public class AllHddMetricsResponses
    {
        public List<HddMetricDto> HddMetrics { get; set; }

        public AllHddMetricsResponses()
        {

        }
    }
}
