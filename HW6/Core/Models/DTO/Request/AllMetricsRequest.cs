﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.DTO.Request
{
    public abstract class AllMetricsRequest
    {        
        protected AllMetricsRequest(TimeSpan from_, TimeSpan to_)
        {
            From = from_;
            To = to_;
        }

        public TimeSpan To { get; set; }
        public TimeSpan From { get; set; }
    }
}
