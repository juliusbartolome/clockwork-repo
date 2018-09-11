using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clockwork.Infrastructure.EFCore.Models
{
    public class ClockworkContext: DbContext
    {
        public DbSet<TimeInquiry> TimeInquiries { get; set; }

        public ClockworkContext()
        {

        }

        public ClockworkContext(DbContextOptions<ClockworkContext> options): base( options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=clockwork.db");
        }
    }
}
