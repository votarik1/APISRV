﻿using Core.Models;
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
    }
}