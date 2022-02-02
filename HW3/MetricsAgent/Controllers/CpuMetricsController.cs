using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MetricsAgent.Models;
using MetricsAgent.DAL;

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
        [HttpGet("Sql-test")]
        public IActionResult TryToSqlLite()
        {
            string cs = "Data Source=:memory:";
            string stm = "Select SQLITE_VERSION()";
            using (var con = new SQLiteConnection(cs))
            {
                _logger.LogInformation("MetricsAgent Logger Works!");
                con.Open();
                using var cmd = new SQLiteCommand(stm, con);
                string version = cmd.ExecuteScalar().ToString();
                return Ok(version);
            }
        }
    }
}
