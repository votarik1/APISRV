using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Xunit;
using Moq;
using AutoMapper;

namespace MetricsManagerTest
{
    public class NetworkMetricsControllerTests
    {

        private NetworkMetricsController controller;
        Mock<ILogger<NetworkMetricsController>> _loggerMock;
        Mock<IMapper> _mapperMock;
        public NetworkMetricsControllerTests()
        {
            _loggerMock = new Mock<ILogger<NetworkMetricsController>>();
            _mapperMock = new Mock<IMapper>();
            controller = new NetworkMetricsController(_loggerMock.Object, _mapperMock.Object);
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