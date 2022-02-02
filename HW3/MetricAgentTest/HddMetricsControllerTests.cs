using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Xunit;
using Moq;

namespace MetricsManagerTest
{
    public class HddMetricsControllerTests
    {

        private HddMetricsController controller;
        Mock<ILogger<HddMetricsController>> _loggerMock;
        Mock<IRepository<HddMetrics>> _repositoryMock;
        public HddMetricsControllerTests()
        {
            _repositoryMock = new Mock<IRepository<HddMetrics>>();
            _loggerMock = new Mock<ILogger<HddMetricsController>>();
            controller = new HddMetricsController(_loggerMock.Object, _repositoryMock.Object);
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