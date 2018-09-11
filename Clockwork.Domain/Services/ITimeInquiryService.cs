using Clockwork.Domain.Entities;
using Clockwork.Domain.Shared;

namespace Clockwork.Domain.Services
{
    public interface ITimeInquiryService
    {
        TimeInquiryEntity GetById(int id);
        PagedResult<TimeInquiryEntity> GetAll(int pageNumber, int pageSize);
        TimeInquiryEntity RecordTimeInquiry(string ipAddress, string timeZoneStandardName);
    }
}
