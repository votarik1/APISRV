using MetricsAgent.Controllers;
using MetricsAgent.DAL;
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
    public class DotNetMetricsControllerTests
    {

        private DotNetMetricsController controller;
        Mock<ILogger<DotNetMetricsController>> _loggerMock;
        Mock<IRepository<DotNetMetric>> _repositoryMock;
        Mock<IMapper> _mapperMock;
        public DotNetMetricsControllerTests()
        {
            _repositoryMock = new Mock<IRepository<DotNetMetric>>();
            _loggerMock = new Mock<ILogger<DotNetMetricsController>>();
            _mapperMock = new Mock<IMapper>();
            controller = new DotNetMetricsController(_loggerMock.Object, _repositoryMock.Object, _mapperMock.Object);
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