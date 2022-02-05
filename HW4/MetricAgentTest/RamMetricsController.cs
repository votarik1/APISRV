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
    public class RamMetricsControllerTests
    {

        private RamMetricsController controller;
        Mock<ILogger<RamMetricsController>> _loggerMock;
        Mock<IRepository<RamMetric>>  _repositiryMock;
        Mock<IMapper> _mapperMock;
        public RamMetricsControllerTests()
        {
            _repositiryMock = new Mock<IRepository<RamMetric>>();
            _loggerMock = new Mock<ILogger<RamMetricsController>>();
            _mapperMock = new Mock<IMapper>();
            controller = new RamMetricsController(_loggerMock.Object,_repositiryMock.Object, _mapperMock.Object);
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