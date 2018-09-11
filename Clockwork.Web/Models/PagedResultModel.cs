using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clockwork.Web.Models
{
    public class PagedResult<TEntity>
    {

        public PagedResult(IEnumerable<TEntity> pageItems, int pageNumber, int pageSize, int totalItemsCount)
        {
            PageItems = pageItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
            PageCount = (int)Math.Ceiling((double)totalItemsCount / pageSize);
            TotalItemsCount = totalItemsCount;
        }

        public IEnumerable<TEntity> PageItems { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int PageCount { get; }
        public int TotalItemsCount { get; }
    }
}