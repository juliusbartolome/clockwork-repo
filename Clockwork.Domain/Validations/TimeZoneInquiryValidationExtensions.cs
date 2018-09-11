using Clockwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Clockwork.Domain.Validations
{
    public static class TimeZoneInquiryValidationExtensions
    {
        public static bool IsValid(this TimeInquiryEntity entity)
        {
            if (entity == null)
                return false;

            if (string.IsNullOrEmpty(entity.IpAddress))
                return false;

            if (string.IsNullOrEmpty(entity.TimeZoneStandardName))
                return false;

            if (!TimeZoneInfo.GetSystemTimeZones().Any(tz => tz.StandardName == entity.TimeZoneStandardName))
                return false;

            return true;
        }
    }
}
