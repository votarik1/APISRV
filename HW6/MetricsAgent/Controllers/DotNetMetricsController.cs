﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models;
using Core.Interfaces;
using AutoMapper;
using Core.Models.DTO.Responses;
using Core.Models.DTO;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/dotnet")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsController> _logger;
        private readonly IRepository<DotNetMetric> _dotnetMetricsRepository;
        private readonly IMapper _mapper;
        public DotNetMetricsController(ILogger<DotNetMetricsController> logger, IRepository<DotNetMetric> dotnetMetricsRepository, IMapper mapper)
        {
            _dotnetMetricsRepository = dotnetMetricsRepository;
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
            IList<DotNetMetric> dotNetMetricsList = _dotnetMetricsRepository.GetByTime(fromTime.TotalSeconds, toTime.TotalSeconds);
            AllDotNetMetricsResponses responses = new AllDotNetMetricsResponses()
            {
                DotNetMetrics = new List<DotNetMetricDto>()
            };
            foreach (DotNetMetric item in dotNetMetricsList)
            {
                responses.DotNetMetrics.Add(_mapper.Map<DotNetMetricDto>(item));
            }
            return Ok(responses);
        }
    }
}