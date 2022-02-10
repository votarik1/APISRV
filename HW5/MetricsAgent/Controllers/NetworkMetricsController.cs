using Microsoft.AspNetCore.Http;
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
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {
        private readonly ILogger<NetworkMetricsController> _logger;
        private readonly IRepository<NetworkMetric> _networkMetricsRepository;
        private readonly IMapper _mapper;
        public NetworkMetricsController(ILogger<NetworkMetricsController> logger, IRepository<NetworkMetric> networkMetricsRepository, IMapper mapper)
        {
            _networkMetricsRepository = networkMetricsRepository;
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<NetworkMetric, NetworkMetricDto>());
            var mapper = config.CreateMapper();
            IList<NetworkMetric> networkMetricsList = _networkMetricsRepository.GetByTime(fromTime.TotalSeconds, toTime.TotalSeconds);
            AllNetworkMetricsResponses responses = new AllNetworkMetricsResponses()
            {
                NetworkMetrics = new List<NetworkMetricDto>()
            };
            foreach (NetworkMetric item in networkMetricsList)
            {
                responses.NetworkMetrics.Add(mapper.Map<NetworkMetricDto>(item));
            }
            return Ok(responses);
        }
    }
}
