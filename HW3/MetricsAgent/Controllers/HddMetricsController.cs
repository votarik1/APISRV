using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Models;
using MetricsAgent.DAL;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd/left")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private readonly ILogger<HddMetricsController> _logger;
        private readonly IRepository<HddMetrics> _hddMetricsRepository;
        public HddMetricsController(ILogger<HddMetricsController> logger, IRepository<HddMetrics> hddMetricsRepository)
        {
            _hddMetricsRepository = hddMetricsRepository;
            _logger = logger;
        }
    }
}
