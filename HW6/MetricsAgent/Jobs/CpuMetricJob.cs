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
    public class CpuMetricJob : IJob
    {
        private IRepository<CpuMetric> _repository;
        private PerformanceCounter _performanceCounter;
        public CpuMetricJob(IRepository<CpuMetric> repository)
        {
            _repository = repository;
            _performanceCounter = new PerformanceCounter("Processor", "% Processor Time","_Total");
        }
        public Task Execute(IJobExecutionContext context)
        {
            int UsageInPercents = Convert.ToInt32(_performanceCounter.NextValue());
            TimeSpan time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new CpuMetric(UsageInPercents, time));
            return Task.CompletedTask;
        }
    }
}
