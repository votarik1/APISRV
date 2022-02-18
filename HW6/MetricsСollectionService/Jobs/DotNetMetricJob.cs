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
    public class DotNetMetricJob:IJob
    {
        private IRepository<DotNetMetric> _repository;
        private IMetricsAgentClient _metricsAgentClient;
        private readonly IMapper _mapper;

        public DotNetMetricJob(IRepository<DotNetMetric> repository, IMetricsAgentClient metricsAgentClient, IMapper mapper)
        {
            _repository = repository;
            _metricsAgentClient = metricsAgentClient;
            _mapper = mapper;
        }
        public Task Execute(IJobExecutionContext context)
        {
            TimeSpan lastTime = _repository.GetLastTimeSpan();
            TimeSpan now = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            AllDotNetMetricsRequest dotNetMetricsRequest = new AllDotNetMetricsRequest(lastTime, now);
            AllDotNetMetricsResponses dotNetMetricsResponses = _metricsAgentClient.GetAllDotNetMetrics(dotNetMetricsRequest);
            if (dotNetMetricsResponses is null)
            {
                return Task.CompletedTask;
            }
            foreach (var item in dotNetMetricsResponses.DotNetMetrics)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<DotNetMetric, DotNetMetricDto>());
                var mapper = config.CreateMapper();
               // _repository.Create(mapper.Map<DotNetMetric>(item));
            }
            return Task.CompletedTask;
        }
    }
}
