using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using AutoMapper;
using System.Net.Http;
using System.Text.Json;
using MetricsManager.Client;
using Core.Models.DTO.Request;

namespace MetricsManager.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly IMapper _mapper;
        private IMetricsAgentClient _metricsAgentClient;

        public CpuMetricsController(ILogger<CpuMetricsController> logger, IMapper mapper, IMetricsAgentClient metricsAgentClient)
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
            var response = _metricsAgentClient.GetAllCpuMetrics(new AllCpuMetricsRequest(fromTime, toTime));
            if (response is null)
            {
                return Problem();
            }
            return Ok(response);
        }
    }
}
