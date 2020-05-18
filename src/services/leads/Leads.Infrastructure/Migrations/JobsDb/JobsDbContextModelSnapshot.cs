﻿// <auto-generated />
using System;
using Leads.Infrastructure.MySqlDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Leads.Infrastructure.Migrations.JobsDb
{
    [DbContext(typeof(JobsDbContext))]
    partial class JobsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Leads.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ParentCategoryId")
                        .HasColumnName("parent_category_id")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasAnnotation("MySql:ValueGeneratedOnAdd", true);

                    b.HasIndex("ParentCategoryId")
                        .HasName("idx_categories_parent_category");

                    b.HasIndex("Name", "ParentCategoryId")
                        .HasName("i_x_categories_name_parent_category_id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Leads.Domain.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnName("category_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("created_at")
                        .HasColumnType("TIMESTAMP")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnName("price")
                        .HasColumnType("int(3)");

                    b.Property<Guid>("ReferenceId")
                        .HasColumnName("reference_id")
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SuburbId")
                        .HasColumnName("suburb_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("updated_at")
                        .HasColumnType("TIMESTAMP")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id")
                        .HasAnnotation("MySql:ValueGeneratedOnAdd", true);

                    b.HasIndex("CategoryId")
                        .HasName("i_x_jobs_category_id");

                    b.HasIndex("ReferenceId")
                        .HasName("i_x_jobs_reference_id");

                    b.HasIndex("SuburbId")
                        .HasName("i_x_jobs_suburb_id");

                    b.ToTable("jobs");
                });

            modelBuilder.Entity("Leads.Domain.Entities.Suburb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PostCode")
                        .HasColumnName("post_code")
                        .HasColumnType("varchar(4)");

                    b.HasKey("Id")
                        .HasAnnotation("MySql:ValueGeneratedOnAdd", true);

                    b.HasIndex("PostCode")
                        .HasName("idx_suburbs_postcode");

                    b.HasIndex("Name", "PostCode")
                        .HasName("i_x_suburbs_name_post_code");

                    b.ToTable("suburbs");
                });

            modelBuilder.Entity("Leads.Domain.Entities.Job", b =>
                {
                    b.HasOne("Leads.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("f_k_jobs_categories_category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Leads.Domain.Entities.Suburb", "Suburb")
                        .WithMany()
                        .HasForeignKey("SuburbId")
                        .HasConstraintName("f_k_jobs_suburbs_suburb_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Leads.Domain.ValueObjects.Contact", "Contact", b1 =>
                        {
                            b1.Property<int>("JobId")
                                .HasColumnName("id")
                                .HasColumnType("int");

                            b1.Property<string>("Email")
                                .HasColumnName("contact_email")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("Name")
                                .HasColumnName("contact_name")
                                .HasColumnType("varchar(255)");

                            b1.Property<string>("Phone")
                                .HasColumnName("contact_phone")
                                .HasColumnType("varchar(255)");

                            b1.HasKey("JobId");

                            b1.ToTable("jobs");

                            b1.WithOwner()
                                .HasForeignKey("JobId")
                                .HasConstraintName("f_k_jobs_jobs_id");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
