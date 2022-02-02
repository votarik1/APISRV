using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;


namespace MetricsAgentTest
{
    public class CpuMetricsControllerTests
    {

        private CpuMetricsController controller;
        Mock<ILogger<CpuMetricsController>> _loggerMock;
        Mock<IRepository<CpuMetrics>> _repositoryMock;
        public CpuMetricsControllerTests()
        {
            _repositoryMock = new Mock<IRepository<CpuMetrics>>();
            _loggerMock = new Mock<ILogger<CpuMetricsController>>();
            controller = new CpuMetricsController(_loggerMock.Object, _repositoryMock.Object);
        }

        [Fact]
        public void GetMetricsFromAgent_ReturnsOk()
        {
            int agentId = 1;
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);

            IActionResult result = controller.GetMetricsFromAgent(agentId, fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromCluster_ReturnsOk()
        {
            TimeSpan fromTime = TimeSpan.FromSeconds(0);
            TimeSpan toTime = TimeSpan.FromSeconds(100);

            IActionResult result = controller.GetMetricsFromCluster(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

       
    }
}
