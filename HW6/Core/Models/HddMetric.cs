using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class HddMetric : Metric
    {
        public HddMetric(int value, TimeSpan time) : base(value, time)
        {
        }

        public HddMetric(long id, long time, long value) : base(id, time, value)
        {
        }

        public HddMetric(int id, int value, TimeSpan time) : base(id, value, time)
        {
        }
    }
}
