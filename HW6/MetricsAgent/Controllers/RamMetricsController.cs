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
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger<RamMetricsController> _logger;
        private readonly IRepository<RamMetric> _ramMetricsRepository;
        private readonly IMapper _mapper;
        public RamMetricsController(ILogger<RamMetricsController> logger, IRepository<RamMetric> ramMetricsRepository, IMapper mapper)
        {
            _ramMetricsRepository = ramMetricsRepository;
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RamMetric, RamMetricDto>());
            var mapper = config.CreateMapper();
            IList<RamMetric> ramMetricsList = _ramMetricsRepository.GetByTime(fromTime.TotalSeconds, toTime.TotalSeconds);
            AllRamMetricsResponses responses = new AllRamMetricsResponses()
            {
                RamMetrics = new List<RamMetricDto>()
            };
            foreach (RamMetric item in ramMetricsList)
            {
                responses.RamMetrics.Add(mapper.Map<RamMetricDto>(item));
            }
            return Ok(responses);
        }
    }
}
