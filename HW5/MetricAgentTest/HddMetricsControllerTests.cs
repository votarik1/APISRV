using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Xunit;
using Moq;
using Core.Interfaces;
using AutoMapper;
using Core.Models;

namespace MetricsAgentTest
{
    public class HddMetricsControllerTests
    {

        private HddMetricsController controller;
        Mock<ILogger<HddMetricsController>> _loggerMock;
        Mock<IRepository<HddMetric>> _repositoryMock;
        Mock<IMapper> _mapperMock;
        public HddMetricsControllerTests()
        {
            _repositoryMock = new Mock<IRepository<HddMetric>>();
            _loggerMock = new Mock<ILogger<HddMetricsController>>();
            _mapperMock = new Mock<IMapper>();
            controller = new HddMetricsController(_loggerMock.Object, _repositoryMock.Object, _mapperMock.Object);
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