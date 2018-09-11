﻿// <auto-generated />
using System;
using Clockwork.Infrastructure.EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clockwork.Infrastructure.EFCore.Migrations
{
    [DbContext(typeof(ClockworkContext))]
    partial class ClockworkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("Clockwork.Infrastructure.EFCore.Models.TimeInquiry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IpAddress");

                    b.Property<string>("TimeZoneStandardName");

                    b.Property<DateTime>("UtcDateTime");

                    b.HasKey("Id");

                    b.ToTable("TimeInquiries");
                });
#pragma warning restore 612, 618
        }
    }
}
