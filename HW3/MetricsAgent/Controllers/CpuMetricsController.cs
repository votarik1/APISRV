using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MetricsAgent.Models;
using MetricsAgent.DAL;
using System;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private readonly ILogger<CpuMetricsController> _logger;
        private readonly IRepository<CpuMetrics> _cpuMetricsRepository;
        public CpuMetricsController(ILogger<CpuMetricsController> logger, IRepository<CpuMetrics> cpuMetricsRepository)
        {
            _logger = logger;
            _cpuMetricsRepository = cpuMetricsRepository;
        }

        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent([FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromCluster([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }


    }
}
