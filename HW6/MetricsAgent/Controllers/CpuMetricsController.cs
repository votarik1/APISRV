using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Core.Models;
using System;
using Core.Interfaces;
using AutoMapper;
using Core.Models.DTO;
using Core.Models.DTO.Responses;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly IRepository<CpuMetric> _cpuMetricsRepository;
        private readonly IMapper _mapper;
        public CpuMetricsController(ILogger<CpuMetricsController> logger, IRepository<CpuMetric> cpuMetricsRepository, IMapper mapper)
        {
            _logger = logger;
            _cpuMetricsRepository = cpuMetricsRepository;
            _mapper = mapper;
        }

        [HttpGet("test")]
        public IActionResult GetMetricsFromAgent()
        {            
            return Ok();
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CpuMetric, CpuMetricDto>());
            var mapper = config.CreateMapper();
            IList<CpuMetric> cpuMetricsList = _cpuMetricsRepository.GetByTime(fromTime.TotalSeconds, toTime.TotalSeconds);
            AllCpuMetricsResponses responses = new AllCpuMetricsResponses()
            {
                CpuMetrics = new List<CpuMetricDto>()
            };
            foreach (CpuMetric item in cpuMetricsList)
            {
                responses.CpuMetrics.Add(mapper.Map<CpuMetricDto>(item));
            }
            return Ok(responses);
        }


    }
}
