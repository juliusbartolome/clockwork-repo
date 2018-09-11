using System;

namespace Clockwork.Web.Models
{
    public class TimeInquiryModel
    {
        public int Id { get; set; }
        public DateTime UtcDateTime { get; set; }
        public string TimeZoneInfoId { get; set; }
        public string IpAddress { get; set; }

        public DateTime ServerTime
        {
            get
            {
                var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneInfoId);
                return TimeZoneInfo.ConvertTimeFromUtc(UtcDateTime, timeZoneInfo);
            }
        }
    }
}