using Core.Interfaces;
using Core.Models;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using MetricsManager.Client;
using AutoMapper;
using Core.Models.DTO.Request;
using Core.Models.DTO.Responses;
using Core.Models.DTO;

namespace MetricsManager.Jobs
{
    public class RamMetricJob : IJob
    {
        private IRepository<RamMetric> _repository;
        private IMetricsAgentClient _metricsAgentClient;
        private readonly IMapper _mapper;
        public RamMetricJob(IRepository<RamMetric> repository, IMetricsAgentClient metricsAgentClient, IMapper mapper)
        {
            _repository = repository;
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
        }
        public Task Execute(IJobExecutionContext context)
        {
            TimeSpan lastTime = _repository.GetLastTimeSpan();
            TimeSpan now = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            AllRamMetricsRequest ramMetricsRequest = new AllRamMetricsRequest(lastTime, now);
            AllRamMetricsResponses ramMetricsResponses = _metricsAgentClient.GetAllRamMetrics(ramMetricsRequest);
            if (ramMetricsResponses is null)
            {
                return Task.CompletedTask;
            }
            foreach (var item in ramMetricsResponses.RamMetrics)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<RamMetric, RamMetricDto>());
                var mapper = config.CreateMapper();
                _repository.Create(mapper.Map<RamMetric>(item));
            }
            return Task.CompletedTask;
        }
    }
}
