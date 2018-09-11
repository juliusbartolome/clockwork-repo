using Clockwork.Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Models
{
    public class TimeInquiryGetDto
    {
        public int Id { get; set; }
        public DateTime UtcDateTime { get; set; }
        public string TimeZoneStandardName { get; set; }
        public string IpAddress { get; set; }
    }
}
