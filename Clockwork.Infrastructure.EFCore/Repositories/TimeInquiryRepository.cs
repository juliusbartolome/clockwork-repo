﻿using Clockwork.Domain.Entities;
using Clockwork.Domain.Repositories;
using Clockwork.Domain.Shared;
using Clockwork.Infrastructure.EFCore.Models;
using Mapster;
using System.Linq;

namespace Clockwork.Infrastructure.EFCore.Repositories
{
    public class TimeInquiryRepository : EfCoreBaseRepository<ClockworkContext, TimeInquiry>, ITimeInquiryRepository
    {
        public void Create(TimeInquiryEntity entity)
        {
            var newTimeInquiryEntry = entity.Adapt<TimeInquiryEntity, TimeInquiry>();

            EntitySet.Add(newTimeInquiryEntry);
            Context.SaveChanges();

            newTimeInquiryEntry.Adapt(entity);
        }

        public PagedResult<TimeInquiryEntity> GetAll(int pageNumber, int pageSize)
        {
            var pageItems = EntitySet.OrderByDescending(e => e.UtcDateTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).ProjectToType<TimeInquiryEntity>().ToList();
            var totalItemsCount = EntitySet.Count();

            return new PagedResult<TimeInquiryEntity>(pageItems, pageNumber, pageSize, totalItemsCount);
        }

        public TimeInquiryEntity GetById(int id)
        {
            return EntitySet.Find(id).Adapt<TimeInquiryEntity>();
        }
    }
}
