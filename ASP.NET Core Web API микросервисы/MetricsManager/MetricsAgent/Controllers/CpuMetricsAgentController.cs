﻿using AutoMapper;
using MetricsAgent.DAL;
using MetricsAgent.Entities;
using MetricsAgent.Requests;
using MetricsAgent.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsAgentController : ControllerBase
    {
        private readonly ILogger<CpuMetricsAgentController> _logger;

        private ICpuMetricsRepository _repository;

        private readonly IMapper _mapper;

        public CpuMetricsAgentController(IMapper mapper,ILogger<CpuMetricsAgentController> logger,ICpuMetricsRepository repository)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _logger.LogDebug(1, "NLog встроен в CpuMetricsAgentController");
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            _repository.Create(new CpuMetric
            {
                Time = request.Time.ToUnixTimeSeconds(),
                Value = request.Value
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var metrics = _repository.GetAll();

            var response = new MetricsResponse()
            {
                Metrics = new List<MetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<MetricDto>(metric));
            }

            return Ok(response);
        }

        [HttpGet("from")]
        public IActionResult GetMetricsFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation("Запущен GetMetricsFromAgent в CpuMetricsAgentController.В него были переданы параметры fromTime:{0} и toTime:{1}", fromTime, toTime);
         
            var metrics = _repository.GetByTimeSpan(fromTime, toTime);

            var response = new MetricsResponse()
            {
                Metrics = new List<MetricDto>()
            };
            response.Metrics = metrics.Select(metric => _mapper.Map<MetricDto>(metric)).ToList();
            return Ok(response);
        }

        [HttpGet("from/{fromTime}/to/{toTime}/percentiles/{percentile}")]
        public IActionResult GetMetricsByPercentileFromAgent([FromRoute] DateTimeOffset fromTime, [FromRoute] DateTimeOffset toTime)
        {
            _logger.LogInformation("Запущен GetMetricsByPercentileFromAgent в CpuMetricsAgentController.В него были переданы параметры fromTime:{0} и toTime:{1}", fromTime, toTime);
            return Ok();
        }

    }
}
