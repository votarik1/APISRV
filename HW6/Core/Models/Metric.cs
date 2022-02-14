﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public abstract class Metric
    {        
        public int ID { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }


        public Metric(int value, TimeSpan time)
        {
            Value = value;
            Time = time;
        }

        public Metric(long id, long time, long value)
        {
            Value = (int)value;
            Time = TimeSpan.FromSeconds(time);
            ID = (int)id;
        }

    }
}
