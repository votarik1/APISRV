using Core.Interfaces;
using Core.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class HddMetricJob : IJob
    {
        private IRepository<HddMetric> _repository;
        private PerformanceCounter _performanceCounter;
        public HddMetricJob(IRepository<HddMetric> repository)
        {
            _performanceCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", "_Total");
            _repository = repository;
        }
        public Task Execute(IJobExecutionContext context)
        {
            int UsageInPercents = Convert.ToInt32(_performanceCounter.NextValue());
            TimeSpan time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new HddMetric(UsageInPercents, time));
            return Task.CompletedTask;
        }
    }
}
