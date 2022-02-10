using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;
using AutoMapper;


namespace MetricsManagerTest
{
    public class CpuMetricsControllerTests
    {

        private CpuMetricsController controller;
        Mock<ILogger<CpuMetricsController>> _loggerMock;
        Mock<IMapper> _mapperMock;
        public CpuMetricsControllerTests()
        {
            _loggerMock = new Mock<ILogger<CpuMetricsController>>();
            _mapperMock = new Mock<IMapper>();
            controller = new CpuMetricsController(_loggerMock.Object, _mapperMock.Object);
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
