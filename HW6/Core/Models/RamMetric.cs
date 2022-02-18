using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class RamMetric : Metric
    {
        public RamMetric(int value, TimeSpan time) : base(value, time)
        {
        }

        public RamMetric(long id, long time, long value) : base(id, time, value)
        {
        }

        public RamMetric(int id, int value, TimeSpan time) : base(id, value, time)
        {
        }
    }
}
