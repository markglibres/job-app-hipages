﻿// <auto-generated />
using System;
using Leads.Infrastructure.MySqlDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leads.Infrastructure.Migrations.JobsQueryDb
{
    [DbContext(typeof(JobsQueryDbContext))]
    partial class JobsQueryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Leads.Domain.Entities.JobInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnName("category_name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ContactEmail")
                        .HasColumnName("contact_email")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ContactName")
                        .HasColumnName("contact_name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ContactPhone")
                        .HasColumnName("contact_phone")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnName("created_at")
                        .HasColumnType("TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<int>("JobId")
                        .HasColumnName("job_id")
                        .HasColumnType("int");

                    b.Property<string>("JobStatus")
                        .HasColumnName("job_status")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Price")
                        .HasColumnName("price")
                        .HasColumnType("int(3)");

                    b.Property<Guid>("ReferenceId")
                        .HasColumnName("reference_id")
                        .HasColumnType("char(36)");

                    b.Property<string>("SuburbName")
                        .HasColumnName("suburb_name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("SuburbPostcode")
                        .HasColumnName("suburb_postcode")
                        .HasColumnType("varchar(4)");

                    b.HasKey("Id")
                        .HasAnnotation("MySql:ValueGeneratedOnAdd", true);

                    b.HasIndex("JobStatus")
                        .HasName("i_x_jobs_info_job_status");

                    b.HasIndex("ReferenceId")
                        .HasName("i_x_jobs_info_reference_id");

                    b.ToTable("jobs_info");
                });
#pragma warning restore 612, 618
        }
    }
}
