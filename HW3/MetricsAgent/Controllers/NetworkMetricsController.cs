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
    [Route("api/metrics/network")]
    [ApiController]
    public class NetworkMetricsController : ControllerBase
    {
        private readonly ILogger<NetworkMetricsController> _logger;
        private readonly IRepository<NetworkMetrics> _networkMetrics;
        public NetworkMetricsController(ILogger<NetworkMetricsController> logger, IRepository<NetworkMetrics> networkMetrics)
        {
            _networkMetrics = networkMetrics;
            _logger = logger;
        }
    }
}
