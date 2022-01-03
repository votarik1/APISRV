using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW1
{
    public class ValuesHolder
    {
        public Dictionary<DateTime,string> Values { get; set; }

        public ValuesHolder()
        {
            Values = new Dictionary<DateTime, string>();
        }

        public Dictionary<DateTime, string> Get() => Values;

        public void ADD(DateTime time, string val) => Values.Add(time, val);
    }
}
