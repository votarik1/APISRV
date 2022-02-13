using Core.Interfaces;
using Core.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using MetricsManager.Client;
using Core.Models.DTO.Request;
using Core.Models.DTO.Responses;
using AutoMapper;
using Core.Models.DTO;

namespace MetricsManager.Jobs
{
    public class CpuMetricJob : IJob
    {
        private IRepository<CpuMetric> _repository;
        private IMetricsAgentClient _metricsAgentClient;
        private readonly IMapper _mapper;
        public CpuMetricJob(IRepository<CpuMetric> repository, IMetricsAgentClient metricsAgentClient, IMapper mapper)
        {
            _repository = repository;
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
        }
        public Task Execute(IJobExecutionContext context)
        {

            TimeSpan lastTime = _repository.GetLastTimeSpan();
            TimeSpan now = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            AllCpuMetricsRequest cpuMetricsRequest = new AllCpuMetricsRequest(lastTime, now);
            AllCpuMetricsResponses cpuMetricsResponses = _metricsAgentClient.GetAllCpuMetrics(cpuMetricsRequest);
            if (cpuMetricsResponses is null)
            {
                return Task.CompletedTask;
            }
            foreach (var item in cpuMetricsResponses.CpuMetrics)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<CpuMetric, CpuMetricDto>());
                var mapper = config.CreateMapper();
                _repository.Create(mapper.Map<CpuMetric>(item));
            }
            return Task.CompletedTask;

        }
    }
}
