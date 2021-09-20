﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Infrastructure.Entity.Employee", b =>
                {
                    b.Property<long>("Employee_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Emp_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Entry_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Entry_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<long>("Salary")
                        .HasColumnType("bigint");

                    b.HasKey("Employee_Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Infrastructure.Entity.Employee+EmployeeQualification", b =>
                {
                    b.Property<long>("Empl_id")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Marks")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("Qualification_id")
                        .HasColumnType("bigint");

                    b.HasKey("Empl_id");

                    b.HasIndex("Qualification_id");

                    b.ToTable("EmployeeQualification");
                });

            modelBuilder.Entity("Infrastructure.Entity.QualificationList", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Q_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("QualificationList");
                });

            modelBuilder.Entity("Infrastructure.Entity.Employee+EmployeeQualification", b =>
                {
                    b.HasOne("Infrastructure.Entity.Employee", "Employee")
                        .WithMany("EmployeeQualifications")
                        .HasForeignKey("Empl_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entity.QualificationList", "QualificationList")
                        .WithMany()
                        .HasForeignKey("Qualification_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("QualificationList");
                });

            modelBuilder.Entity("Infrastructure.Entity.Employee", b =>
                {
                    b.Navigation("EmployeeQualifications");
                });
#pragma warning restore 612, 618
        }
    }
}
