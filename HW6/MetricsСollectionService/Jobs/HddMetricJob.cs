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
    public class HddMetricJob : IJob
    {
        private IRepository<HddMetric> _repository;
        private IMetricsAgentClient _metricsAgentClient;
        private readonly IMapper _mapper;
        public HddMetricJob(IRepository<HddMetric> repository, IMapper mapper, IMetricsAgentClient metricsAgentClient)
        {
            _repository = repository;
            _mapper = mapper;
            _metricsAgentClient = metricsAgentClient;
        }
        public Task Execute(IJobExecutionContext context)
        {
            TimeSpan lastTime = _repository.GetLastTimeSpan();
            TimeSpan now = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            AllHddMetricsRequest hddMetricsRequest = new AllHddMetricsRequest(lastTime, now);
            AllHddMetricsResponses hddMetricsResponses = _metricsAgentClient.GetAllHddMetrics(hddMetricsRequest);
            if (hddMetricsResponses is null)
            {
                return Task.CompletedTask;
            }
            foreach (var item in hddMetricsResponses.HddMetrics)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<HddMetric, HddMetricDto>());
                var mapper = config.CreateMapper();
               // _repository.Create(mapper.Map<HddMetric>(item));
            }
            return Task.CompletedTask;
        }
    }
}
