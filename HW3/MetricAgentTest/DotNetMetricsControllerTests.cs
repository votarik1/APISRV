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
    public class DotNetMetricsControllerTests
    {

        private DotNetMetricsController controller;
        Mock<ILogger<DotNetMetricsController>> _loggerMock;
        Mock<IRepository<DotNetMetrics>> _repositoryMock;
        public DotNetMetricsControllerTests()
        {
            _repositoryMock = new Mock<IRepository<DotNetMetrics>>();
            _loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            controller = new DotNetMetricsController(_loggerMock.Object, _repositoryMock.Object);
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