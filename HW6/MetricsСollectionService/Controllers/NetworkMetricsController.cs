﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsManager.Client;
using Core.Models.DTO.Request;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/metrics/network")]
    public class NetworkMetricsController : ControllerBase
    {
        private readonly ILogger<NetworkMetricsController> _logger;
        private readonly IMapper _mapper;
        private IMetricsAgentClient _metricsAgentClient;
        public NetworkMetricsController(ILogger<NetworkMetricsController> logger, IMapper mapper, IMetricsAgentClient metricsAgentClient)
        {
            _logger = logger;
            _mapper = mapper;
            _metricsAgentClient = metricsAgentClient;
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
            var response = _metricsAgentClient.GetAllNetworkMetrics(new AllNetworkMetricsRequest(fromTime, toTime));
            if (response is null)
            {
                return Problem();
            }
            return Ok(response);
        }
    }
}
