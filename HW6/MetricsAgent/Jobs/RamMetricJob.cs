using Core.Interfaces;
using Core.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MetricsAgent.Jobs
{
    public class RamMetricJob : IJob
    {
        private IRepository<RamMetric> _repository;
        private PerformanceCounter _performanceCounter;
        public RamMetricJob(IRepository<RamMetric> repository)
        {
            _repository = repository;
            _performanceCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        public Task Execute(IJobExecutionContext context)
        {
            int UsageInPercents = Convert.ToInt32(_performanceCounter.NextValue());
            TimeSpan time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new RamMetric(UsageInPercents, time));
            return Task.CompletedTask;
        }
    }
}
