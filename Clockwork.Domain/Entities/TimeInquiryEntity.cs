using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.Domain.Entities
{
    public class TimeInquiryEntity
    {
        public int Id { get; set; }
        public DateTime UtcDateTime { get; set; }
        public string TimeZoneInfoId { get; set; }
        public string IpAddress { get; set; }
    }
}
