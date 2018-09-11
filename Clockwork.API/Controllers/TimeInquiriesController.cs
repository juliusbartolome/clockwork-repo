using System;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using Clockwork.Domain.Services;
using Microsoft.Extensions.Logging;
using Mapster;

namespace Clockwork.API.Controllers
{
    [Route("api/[controller]")]
    public class TimeInquiriesController : Controller
    {
        private readonly ITimeInquiryService _timeInquiryService;
        private readonly ILogger<TimeInquiriesController> _logger;

        public TimeInquiriesController(ITimeInquiryService timeInquiryService, ILogger<TimeInquiriesController> logger)
        {
            _timeInquiryService = timeInquiryService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var retrievedEntity = _timeInquiryService.GetById(id.Value);
            if (retrievedEntity == null)
                return NotFound();

            return Ok(retrievedEntity);
        }

        [HttpGet]
        public IActionResult GetAll(int? pageNumber = 1, int? pageSize = 10)
        {
            var retrievedEntities = _timeInquiryService.GetAll(pageNumber.Value, pageSize.Value);
            return Ok(retrievedEntities);
        }

        [HttpPost]
        public IActionResult Post([FromBody]TimeInquiryPostDto timeInquiryPostDto)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var timeZoneInfoId = timeInquiryPostDto.TimeZoneInfoId;
            if (string.IsNullOrEmpty(timeZoneInfoId))
                timeZoneInfoId = TimeZoneInfo.Local.Id;

            try
            {
                var createdEntity = _timeInquiryService.RecordTimeInquiry(ipAddress, timeZoneInfoId);
                _logger.LogInformation($"Successfully created a new time inquiry {nameof(createdEntity.Id)}.");
                return CreatedAtAction(nameof(GetById), new { id = createdEntity.Id }, createdEntity.Adapt<TimeInquiryGetDto>());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occured in {nameof(TimeInquiriesController)}.{nameof(Post)}.");
                return StatusCode(500);
            }
        }
    }
}
