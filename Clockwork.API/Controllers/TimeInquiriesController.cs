using System;
using Microsoft.AspNetCore.Mvc;
using Clockwork.API.Models;
using Clockwork.Domain.Services;
using Microsoft.Extensions.Logging;

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

        [HttpPost]
        public IActionResult Post(TimeInquiryPostDto timeInquiryPostDto)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            var timeZoneStandardName = timeInquiryPostDto.TimeZoneStandardName;
            if (string.IsNullOrEmpty(timeZoneStandardName))
                timeZoneStandardName = TimeZoneInfo.Local.StandardName;

            try
            {
                var createdEntity = _timeInquiryService.RecordTimeInquiry(ipAddress, timeZoneStandardName);
                _logger.LogInformation($"Successfully created a new time inquiry {nameof(createdEntity.Id)}.");
                return Ok(createdEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occured in {nameof(TimeInquiriesController)}.{nameof(Post)}.");
                return StatusCode(500);
            }
        }
    }
}
