using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clockwork.Domain.Utilities
{
    public static class TimeZoneUtility
    {
        public static TimeZoneInfo ResolveTimeZone(string timeZoneStandardName)
        {
            return TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(tz => tz.StandardName == timeZoneStandardName);
        }
    }
}
