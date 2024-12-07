﻿// <auto-generated />
using System;
using DemoMixvel.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoMixvel.Database.Migrations
{
    [DbContext(typeof(RouteDbContext))]
    partial class RouteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoMixvel.Database.Entity.Route", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("DestinationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime>("OriginDateTime")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("TimeLimit")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Origin", "Destination", "OriginDateTime");

                    b.ToTable("Routes");

                    b.HasCheckConstraint("CK_Route_Dates", "[OriginDateTime] < [DestinationDateTime]");

                    b.HasCheckConstraint("CK_Route_Price", "[Price] > 0");
                });
#pragma warning restore 612, 618
        }
    }
}