using System;

namespace Clockwork.API.Models
{
    public class TimeInquiryGetDto
    {
        public int Id { get; set; }
        public DateTime UtcDateTime { get; set; }
        public string TimeZoneInfoId { get; set; }
        public string IpAddress { get; set; }
    }
}
