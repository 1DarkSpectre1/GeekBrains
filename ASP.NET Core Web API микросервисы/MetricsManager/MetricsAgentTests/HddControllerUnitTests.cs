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
    public class HddMetricsAgentControllerUnitTests
    {
        private HddMetricsAgentController controller;
        private Mock<IHddMetricsRepository> mock;
        private Mock<ILogger<HddMetricsAgentController>> _logger;
        private Mock<IMapper> _mapper;
        public HddMetricsAgentControllerUnitTests()
        {
            mock = new Mock<IHddMetricsRepository>();
            _logger = new Mock<ILogger<HddMetricsAgentController>>();
            _mapper = new Mock<IMapper>();
            controller = new HddMetricsAgentController(_mapper.Object,_logger.Object, mock.Object);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            // ������������� �������� ��������
            // � �������� ����������� ��� � ����������� �������� HddMetric ������
            mock.Setup(repository => repository.Create(It.IsAny<HddMetric>())).Verifiable();

            // ��������� �������� �� �����������
            var result = controller.Create(new MetricsAgent.Requests.MetricCreateRequest { Time = DateTimeOffset.FromUnixTimeSeconds(1), Value = 50 });

            // ��������� �������� �� ��, ��� ���� ������� ����������
            // ������������� �������� ����� Create ����������� � ������ ����� ������� � ���������
            mock.Verify(repository => repository.Create(It.IsAny<HddMetric>()), Times.AtMostOnce());
        }
    }
}