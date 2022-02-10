using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Responses
{
   public abstract class MetricDto
    {
        public int ID { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }
    }
}
