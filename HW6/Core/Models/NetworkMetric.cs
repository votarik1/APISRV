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

        public NetworkMetric(System.Int64 Id, System.Int64 Time, System.Int64 Value) : base(Id, Time, Value)
        {
        }
    }
}
