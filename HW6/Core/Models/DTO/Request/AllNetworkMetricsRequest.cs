using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTO.Request
{
    public class AllNetworkMetricsRequest : AllMetricsRequest
    {
        public AllNetworkMetricsRequest(TimeSpan from, TimeSpan to) : base(from, to)
        {
        }
    }
}
