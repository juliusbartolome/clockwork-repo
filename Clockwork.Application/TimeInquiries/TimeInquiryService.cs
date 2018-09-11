using Clockwork.Domain.Entities;
using Clockwork.Domain.Repositories;
using Clockwork.Domain.Services;
using Clockwork.Domain.Shared;
using Clockwork.Domain.Utilities;
using Clockwork.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.Application.TimeInquiries
{
    public class TimeInquiryService : ITimeInquiryService
    {
        private readonly ITimeInquiryRepository _timeInquiryRepository;

        public TimeInquiryService(ITimeInquiryRepository timeInquiryRepository)
        {
            _timeInquiryRepository = timeInquiryRepository ?? throw new ArgumentNullException(nameof(timeInquiryRepository));
        }

        public PagedResult<TimeInquiryEntity> GetAll(int pageNumber, int pageSize)
        {
            if (pageNumber == 0)
                throw new ArgumentException("Value cannot be set to zero.", nameof(pageNumber));

            if (pageSize == 0)
                throw new ArgumentException("Value cannot be set to zero.", nameof(pageSize));

            return _timeInquiryRepository.GetAll(pageNumber, pageSize);
        }

        public TimeInquiryEntity RecordTimeInquiry(string ipAddress, string timeZoneStandardName)
        {
            if (!string.IsNullOrEmpty(ipAddress))
                throw new ArgumentException("Cannot be null or empty.", nameof(ipAddress));

            var currentTimeZoneInfo = TimeZoneUtilities.ResolveTimeZone(timeZoneStandardName);
            if (currentTimeZoneInfo == null)
                throw new ArgumentException($"Invalid {nameof(timeZoneStandardName)} and cannot resolve to a proper {nameof(TimeZoneInfo)}.", nameof(timeZoneStandardName));

            var entity = new TimeInquiryEntity { IpAddress = ipAddress, UtcDateTime = DateTime.UtcNow, TimeZoneStandardName = timeZoneStandardName };
            _timeInquiryRepository.Create(entity);

            return entity;
        }
    }
}
