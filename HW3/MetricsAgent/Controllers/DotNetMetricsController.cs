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
    [Route("api/metrics/dotnet/errors-count")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private readonly ILogger<DotNetMetricsController> _logger;
        private readonly IRepository<DotNetMetrics> _dotnetMetricsRepository;
        public DotNetMetricsController(ILogger<DotNetMetricsController> logger, IRepository<DotNetMetrics> dotnetMetricsRepository)
        {
            _dotnetMetricsRepository = dotnetMetricsRepository;
            _logger = logger;
        }
    }
}
