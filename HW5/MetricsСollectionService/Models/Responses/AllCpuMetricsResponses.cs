﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Models.Responses
{
    public class AllCpuMetricsResponses
    {
        public List<CpuMetricDto> CpuMetrics { get; set; }
    }
}
