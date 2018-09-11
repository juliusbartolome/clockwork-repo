using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.Infrastructure.EFCore.Models
{
    public class ClockworkContextFactory : IDesignTimeDbContextFactory<ClockworkContext>
    {
        public ClockworkContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClockworkContext>();
            optionsBuilder.UseSqlite("Data Source=../Clockwork.API/clockwork.db");

            return new ClockworkContext(optionsBuilder.Options);
        }
    }
}
