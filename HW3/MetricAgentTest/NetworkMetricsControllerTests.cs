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
    public class NetworkMetricsControllerTests
    {

        private NetworkMetricsController controller;
        Mock<ILogger<NetworkMetricsController>> _loggerMock;
        Mock<IRepository<NetworkMetrics>> _repositiryMock;
        public NetworkMetricsControllerTests()
        {
            _repositiryMock = new Mock<IRepository<NetworkMetrics>>();
            _loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            controller = new NetworkMetricsController(_loggerMock.Object, _repositiryMock.Object);
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