using Microsoft.AspNetCore.Http;
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
    [Route("api/metrics/hdd")]
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
            IList<HddMetric> hddMetricsList = _hddMetricsRepository.GetByTime(fromTime.TotalSeconds, toTime.TotalSeconds);
            AllHddMetricsResponses responses = new AllHddMetricsResponses()
            {
                HddMetrics = new List<HddMetricDto>()
            };
            foreach (HddMetric item in hddMetricsList)
            {
                responses.HddMetrics.Add(_mapper.Map<HddMetricDto>(item));
            }
            return Ok(responses);
        }
    }
}
