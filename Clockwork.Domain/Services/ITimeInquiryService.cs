using Clockwork.Domain.Entities;
using Clockwork.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.Domain.Services
{
    public interface ITimeInquiryService
    {
        TimeInquiryEntity RecordTimeInquiry(string ipAddress, string timeZoneStandardName);
        PagedResult<TimeInquiryEntity> GetAll(int pageNumber, int pageSize);
    }
}
