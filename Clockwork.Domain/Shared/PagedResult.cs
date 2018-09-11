using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.Domain.Shared
{
    public class PagedResult<TEntity>
    {

        public PagedResult(IReadOnlyCollection<TEntity> pageItems, int pageNumber, int pageSize, int totalItemsCount)
        {
            PageItems = pageItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
            PageCount = (int)Math.Ceiling((double)totalItemsCount / pageSize);
            TotalItemsCount = totalItemsCount;
        }

        public IReadOnlyCollection<TEntity> PageItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int PageCount { get; }
        public int TotalItemsCount { get; }
    }
}
