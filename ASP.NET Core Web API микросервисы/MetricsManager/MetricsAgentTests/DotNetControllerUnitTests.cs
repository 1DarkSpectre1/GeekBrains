using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.DAL;
using MetricsAgent.Entities;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentTests
{
    public class DotNetMetricsAgentControllerUnitTests
    {
        private DotNetMetricsAgentController controller;
        private Mock<IDotNetMetricsRepository> mock;
        private Mock<ILogger<DotNetMetricsAgentController>> _logger;
        private Mock<IMapper> _mapper;
        public DotNetMetricsAgentControllerUnitTests()
        {
            mock = new Mock<IDotNetMetricsRepository>();
            _logger = new Mock<ILogger<DotNetMetricsAgentController>>();
            _mapper = new Mock<IMapper>();
            controller = new DotNetMetricsAgentController(_mapper.Object,_logger.Object, mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� DotNetMetric ������
            mock.Setup(repository => repository.Create(It.IsAny<DotNetMetric>())).Verifiable();

            // ��������� �������� �� �����������
            var result = controller.Create(new MetricsAgent.Requests.MetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(1), Value = 50 });

            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<DotNetMetric>()), Times.AtMostOnce());
        }
    }
}
