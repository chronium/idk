﻿// <auto-generated />
using System;
using Idk.Persistence.Manager;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Idk.Persistence.Manager.Migrations
{
    [DbContext(typeof(ManagerContext))]
    partial class ManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Idk.Persistence.Manager.Models.DbTenant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newsequentialid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Subdomain")
                        .IsRequired()
                        .HasMaxLength(63)
                        .HasColumnType("nvarchar(63)");

                    b.HasKey("Id");

                    b.ToTable("Tenant");
                });
#pragma warning restore 612, 618
        }
    }
}
