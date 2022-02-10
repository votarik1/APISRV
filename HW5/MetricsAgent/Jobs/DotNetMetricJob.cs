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
    public class DotNetMetricJob:IJob
    {
        private IRepository<DotNetMetric> _repository;
        private PerformanceCounter _performanceCounter;
        public DotNetMetricJob(IRepository<DotNetMetric> repository)
        {
            _repository = repository;
            _performanceCounter = new PerformanceCounter(".NET CLR Memory","% Time in GC","_Global_");
        }
        public Task Execute(IJobExecutionContext context)
        {
            int UsageInPercents = Convert.ToInt32(_performanceCounter.NextValue());
            TimeSpan time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new DotNetMetric(UsageInPercents,time));
            return Task.CompletedTask;
        }
    }
}
