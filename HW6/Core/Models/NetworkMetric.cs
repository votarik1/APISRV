using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class NetworkMetric : Metric
    {


        public NetworkMetric(int value, TimeSpan time) : base(value, time)
        {

        }

        public NetworkMetric(long id, long time, long value) : base(id, time, value)
        {
        }
    }
}
