using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Core.Models.DTO;
using Core.Models.DTO.Request;
using Core.Models.DTO.Responses;
using MetricsManager.Client;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private IRepository<NetworkMetric> _repository;
        private IMetricsAgentClient _metricsAgentClient;
        private readonly IMapper _mapper;
        public NetworkMetricJob(IRepository<NetworkMetric> repository, IMetricsAgentClient metricsAgentClient, IMapper mapper)
        {
            _repository = repository;
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
        }
        public Task Execute(IJobExecutionContext context)
        {
            TimeSpan lastTime = _repository.GetLastTimeSpan();
            TimeSpan now = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            AllNetworkMetricsRequest networkMetricsRequest = new AllNetworkMetricsRequest(lastTime, now);
            AllNetworkMetricsResponses networkMetricsResponses = _metricsAgentClient.GetAllNetworkMetrics(networkMetricsRequest);
            if (networkMetricsResponses is null)
            {
                return Task.CompletedTask;
            }
            foreach (var item in networkMetricsResponses.NetworkMetrics)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<NetworkMetric, NetworkMetricDto>());
                var mapper = config.CreateMapper();
               // _repository.Create(mapper.Map<NetworkMetric>(item));
            }
            return Task.CompletedTask;
        }
    }
}
