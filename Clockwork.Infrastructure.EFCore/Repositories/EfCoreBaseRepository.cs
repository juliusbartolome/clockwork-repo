using Clockwork.Infrastructure.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.Infrastructure.EFCore.Repositories
{
    public class EfCoreBaseRepository<TDbContext, TEntity> : IDisposable
        where TDbContext : DbContext
        where TEntity : class
    {
        private bool _disposed = false;

        protected readonly TDbContext Context;
        protected readonly DbSet<TEntity> EntitySet;

        public EfCoreBaseRepository()
        {
            Context = (TDbContext)Activator.CreateInstance(typeof(TDbContext));
            EntitySet = Context.Set<TEntity>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Context.Dispose();
            }

            _disposed = true;
        }

        ~EfCoreBaseRepository()
        {
            Dispose(false);
        }
    }
}
