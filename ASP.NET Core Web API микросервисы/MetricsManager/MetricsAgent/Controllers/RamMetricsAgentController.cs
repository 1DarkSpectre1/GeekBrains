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
    [Route("api/metrics/ram")]
    [ApiController]
    public class RamMetricsAgentController : ControllerBase
    {
        private readonly ILogger<RamMetricsAgentController> _logger;

        private IRamMetricsRepository _repository;

        private readonly IMapper _mapper;

        public RamMetricsAgentController(IMapper mapper, ILogger<RamMetricsAgentController> logger, IRamMetricsRepository repository)
        {
            _mapper = mapper;
            _logger = logger;
            _repository = repository;
            _logger.LogDebug(1, "NLog встроен в RamMetricsAgentController");
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] MetricCreateRequest request)
        {
            _repository.Create(new RamMetric
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
            _logger.LogInformation("Запущен GetMetricsFromAgent в RamMetricsAgentController.В него были переданы параметры fromTime:{0} и toTime:{1}", fromTime, toTime);
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
        [HttpGet("available")]
        public IActionResult GetMetricsFromAgent()
        {
            _logger.LogInformation("Запущен GetMetricsFromAgent в RamMetricsAgentControllerr.");
            return Ok();
        }
    }
}
