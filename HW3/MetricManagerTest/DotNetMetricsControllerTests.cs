using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Xunit;
using Moq;


namespace MetricsManagerTest
{
    public class DotNetMetricsControllerTests
    {

        private DotNetMetricsController controller;
        Mock<ILogger<DotNetMetricsController>> _loggerMock;
        public DotNetMetricsControllerTests()
        {
            _loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            controller = new DotNetMetricsController(_loggerMock.Object);
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