using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class RamMetricsAgentControllerUnitTests
    {
        private RamMetricsAgentController controller;
        private Mock<IRamMetricsRepository> mock;
        private Mock<ILogger<RamMetricsAgentController>> _logger;

        public RamMetricsAgentControllerUnitTests()
        {
            mock = new Mock<IRamMetricsRepository>();
            _logger = new Mock<ILogger<RamMetricsAgentController>>();
            controller = new RamMetricsAgentController(_logger.Object, mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� RamMetric ������
            mock.Setup(repository => repository.Create(It.IsAny<RamMetric>())).Verifiable();

            // ��������� �������� �� �����������
            var result = controller.Create(new MetricsAgent.Requests.MetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(1), Value = 50 });

            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<RamMetric>()), Times.AtMostOnce());
        }
    }
}