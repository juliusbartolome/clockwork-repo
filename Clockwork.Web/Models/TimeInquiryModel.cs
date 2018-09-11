using System;

namespace Clockwork.Web.Models
{
    public class TimeInquiryModel
    {
        public int Id { get; set; }
        public DateTime UtcDateTime { get; set; }
        public string TimeZoneStandardName { get; set; }
        public string IpAddress { get; set; }

        public DateTime ServerTime
        {
            get
            {
                var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneStandardName) ?? TimeZoneInfo.Local;
                return TimeZoneInfo.ConvertTimeFromUtc(UtcDateTime, timeZoneInfo);
            }
        }
    }
}