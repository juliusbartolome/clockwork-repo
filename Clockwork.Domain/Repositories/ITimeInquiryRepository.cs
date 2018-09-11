using Clockwork.Domain.Entities;
using Clockwork.Domain.Shared;

namespace Clockwork.Domain.Repositories
{
    public interface ITimeInquiryRepository
    {
        TimeInquiryEntity GetById(int id);
        PagedResult<TimeInquiryEntity> GetAll(int pageNumber, int pageSize);
        void Create(TimeInquiryEntity entity);
    }
}
