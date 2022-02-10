﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using MetricsAgent.DAL;
using Core.Interfaces;
using AutoMapper;
using MetricsAgent.Models;
using MetricsAgent.Models.Responses;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd/left")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly ILogger<HddMetricsController> _logger;
        private readonly IRepository<HddMetric> _hddMetricsRepository;
        private readonly IMapper _mapper;
        public HddMetricsController(ILogger<HddMetricsController> logger, IRepository<HddMetric> hddMetricsRepository, IMapper mapper)
        {
            _hddMetricsRepository = hddMetricsRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"agentId {agentId}, fromTime {fromTime.TotalSeconds}, toTime {toTime.TotalSeconds}");
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogInformation($"fromTime {fromTime.TotalSeconds}, toTime {toTime.TotalSeconds}");
            var config = new MapperConfiguration(cfg => cfg.CreateMap<HddMetric, HddMetricDto>());
            var mapper = config.CreateMapper();
            IList<HddMetric> hddMetricsList = _hddMetricsRepository.GetByTime(fromTime.TotalSeconds, toTime.TotalSeconds);
            AllHddMetricsResponses responses = new AllHddMetricsResponses()
            {
                HddMetrics = new List<HddMetricDto>()
            };
            foreach (HddMetric item in hddMetricsList)
            {
                responses.HddMetrics.Add(mapper.Map<HddMetricDto>(item));
            }
            return Ok(responses);
        }
    }
}