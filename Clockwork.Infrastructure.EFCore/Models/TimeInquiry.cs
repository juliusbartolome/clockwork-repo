using Clockwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clockwork.Infrastructure.EFCore.Models
{
    public class TimeInquiry
    {
        public int Id { get; set; }
        public DateTime UtcDateTime { get; set; }
        public string TimeZoneStandardName { get; set; }
        public string IpAddress { get; set; }
    }
}
