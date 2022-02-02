using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Xunit;
using Moq;

namespace MetricsAgentTest
{
    public class RamMetricsControllerTests
    {

        private RamMetricsController controller;
        Mock<ILogger<RamMetricsController>> _loggerMock;
        Mock<IRepository<RamMetrics>>  _repositiryMock;
        public RamMetricsControllerTests()
        {
            _repositiryMock = new Mock<IRepository<RamMetrics>>();
            _loggerMock = new Mock<ILogger<RamMetricsController>>();
            controller = new RamMetricsController(_loggerMock.Object,_repositiryMock.Object);
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