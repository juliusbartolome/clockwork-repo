using Clockwork.Domain.Entities;
using Clockwork.Domain.Repositories;
using Clockwork.Domain.Services;
using Clockwork.Domain.Shared;
using System;

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

        public TimeInquiryEntity GetById(int id)
        {
            return _timeInquiryRepository.GetById(id);
        }

        public TimeInquiryEntity RecordTimeInquiry(string ipAddress, string timeZoneInfoId)
        {
            if (string.IsNullOrEmpty(ipAddress))
                throw new ArgumentException("Cannot be null or empty.", nameof(ipAddress));

            var currentTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneInfoId);
            if (currentTimeZoneInfo == null)
                throw new ArgumentException($"Invalid {nameof(timeZoneInfoId)} and cannot resolve to a proper {nameof(TimeZoneInfo)}.", nameof(timeZoneInfoId));

            var entity = new TimeInquiryEntity { IpAddress = ipAddress, UtcDateTime = DateTime.UtcNow, TimeZoneInfoId = timeZoneInfoId };
            _timeInquiryRepository.Create(entity);

            return entity;
        }
    }
}
