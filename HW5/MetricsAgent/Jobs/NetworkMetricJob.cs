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
    public class NetworkMetricJob : IJob
    {
        private IRepository<NetworkMetric> _repository;
        private PerformanceCounter _performanceCounter;
        public NetworkMetricJob(IRepository<NetworkMetric> repository)
        {
            _repository = repository;
            _performanceCounter = new PerformanceCounter("Network Interface", "Bytes Total/sec", "Intel[R] Dual Band Wireless-AC 7265");
        }
        public Task Execute(IJobExecutionContext context)
        {
            int UsageInPercents = Convert.ToInt32(_performanceCounter.NextValue());
            TimeSpan time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            _repository.Create(new NetworkMetric(UsageInPercents, time));
            return Task.CompletedTask;
        }
    }
}
