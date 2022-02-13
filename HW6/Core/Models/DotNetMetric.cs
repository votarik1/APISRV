using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core.Models
{
    public class DotNetMetric:Metric
    {
        

        public DotNetMetric(int value, TimeSpan time) : base(value, time)
        {

        }

        public DotNetMetric(long Id, long Time, long Value) : base(Id, Time, Value)
        {
        }
    }
}
