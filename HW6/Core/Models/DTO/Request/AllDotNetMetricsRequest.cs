using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTO.Request
{
    public class AllDotNetMetricsRequest : AllMetricsRequest
    {
        public AllDotNetMetricsRequest(TimeSpan from, TimeSpan to) : base(from, to)
        {
        }
    }
}
