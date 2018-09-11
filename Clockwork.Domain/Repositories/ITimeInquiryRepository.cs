using Clockwork.Domain.Entities;
using Clockwork.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.Domain.Repositories
{
    public interface ITimeInquiryRepository
    {
        PagedResult<TimeInquiryEntity> GetAll(int pageNumber, int pageSize);
        void Create(TimeInquiryEntity entity);
    }
}
