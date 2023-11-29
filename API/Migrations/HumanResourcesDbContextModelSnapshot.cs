﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(HumanResourcesDbContext))]
    partial class HumanResourcesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("bit")
                        .HasColumnName("is_disabled");

                    b.Property<bool>("IsOtpUsed")
                        .HasColumnType("bit")
                        .HasColumnName("is_otp_used");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<int>("OTP")
                        .HasColumnType("int")
                        .HasColumnName("otp");

                    b.Property<DateTime>("OtpExpiredTime")
                        .HasColumnType("datetime2")
                        .HasColumnName("otp_expired_time");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("password");

                    b.HasKey("Guid");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("tb_accounts");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4838),
                            Email = "john.doe@example.com",
                            IsDisabled = false,
                            IsOtpUsed = true,
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4839),
                            OTP = 123456,
                            OtpExpiredTime = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4840),
                            Password = "$2a$12$mvo2XQ5OGmiYMXdhsNEv5uHtl2D0BVfz/yEaZO6xmPtJzQgoJIFEm"
                        },
                        new
                        {
                            Guid = new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 610, DateTimeKind.Local).AddTicks(6064),
                            Email = "jane.smith@example.com",
                            IsDisabled = false,
                            IsOtpUsed = true,
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 610, DateTimeKind.Local).AddTicks(6065),
                            OTP = 123456,
                            OtpExpiredTime = new DateTime(2023, 11, 28, 18, 20, 27, 610, DateTimeKind.Local).AddTicks(6066),
                            Password = "$2a$12$2HIg78Ra3XYp3OgNYlKo0.rdcVkESeGojVEp0mrMKwaQDU5dGbXRW"
                        },
                        new
                        {
                            Guid = new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 908, DateTimeKind.Local).AddTicks(121),
                            Email = "bob.johnson@example.com",
                            IsDisabled = false,
                            IsOtpUsed = true,
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 908, DateTimeKind.Local).AddTicks(122),
                            OTP = 123456,
                            OtpExpiredTime = new DateTime(2023, 11, 28, 18, 20, 27, 908, DateTimeKind.Local).AddTicks(123),
                            Password = "$2a$12$dE8nYE5UDZUyI3F78G/96.CncktYpQSYXLhkM5TuuWQuJBjpSeis6"
                        });
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<Guid>("AccountGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("account_guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<Guid>("RoleGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("role_guid");

                    b.HasKey("Guid");

                    b.HasIndex("AccountGuid");

                    b.HasIndex("RoleGuid");

                    b.ToTable("tb_account_roles");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("914ae5ba-a980-46e7-927c-71f82589157b"),
                            AccountGuid = new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(3931),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(3936),
                            RoleGuid = new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f")
                        },
                        new
                        {
                            Guid = new Guid("ca3c3fef-ed8c-4c2e-a8e3-5810afeaee74"),
                            AccountGuid = new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(3975),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(3976),
                            RoleGuid = new Guid("8d1da011-8574-4be4-9f64-657254f764d6")
                        },
                        new
                        {
                            Guid = new Guid("06142e7c-a9ef-47bc-9c7a-87553b5d3b8d"),
                            AccountGuid = new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4003),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4003),
                            RoleGuid = new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394")
                        });
                });

            modelBuilder.Entity("API.Models.Department", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid?>("ManagerGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("manager_guid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ManagerGuid")
                        .IsUnique()
                        .HasFilter("[manager_guid] IS NOT NULL");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_departments");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"),
                            Code = "01",
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4583),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4595),
                            Name = "Finance"
                        },
                        new
                        {
                            Guid = new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"),
                            Code = "06",
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4597),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4598),
                            Name = "Information Technology"
                        },
                        new
                        {
                            Guid = new Guid("e8246140-6e0a-488e-b451-9321b6694736"),
                            Code = "07",
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4600),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4600),
                            Name = "Human Resources"
                        });
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("DepartmentGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("department_guid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("hiring_date");

                    b.Property<Guid>("JobGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("job_guid");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("phone_number");

                    b.HasKey("Guid");

                    b.HasIndex("DepartmentGuid");

                    b.HasIndex("JobGuid");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("tb_employees");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                            BirthDate = new DateTime(1990, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4788),
                            DepartmentGuid = new Guid("7644ad73-57b6-4640-9e8d-f929ba01e694"),
                            FirstName = "John",
                            Gender = 1,
                            HiringDate = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobGuid = new Guid("1105117d-ed96-4206-bd43-0e13b7342770"),
                            LastName = "Doe",
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4788),
                            PhoneNumber = "+123456789"
                        },
                        new
                        {
                            Guid = new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                            BirthDate = new DateTime(1985, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4799),
                            DepartmentGuid = new Guid("9e0e4c05-cde2-4900-88f9-2a2b8ee0dad6"),
                            FirstName = "Jane",
                            Gender = 0,
                            HiringDate = new DateTime(2019, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobGuid = new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
                            LastName = "Smith",
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4800),
                            PhoneNumber = "+987654321"
                        },
                        new
                        {
                            Guid = new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                            BirthDate = new DateTime(1982, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4807),
                            DepartmentGuid = new Guid("e8246140-6e0a-488e-b451-9321b6694736"),
                            FirstName = "Bob",
                            Gender = 1,
                            HiringDate = new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobGuid = new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
                            LastName = "Johnson",
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4807),
                            PhoneNumber = "+1122334455"
                        });
                });

            modelBuilder.Entity("API.Models.Job", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<int>("MaxSalary")
                        .HasColumnType("int")
                        .HasColumnName("max_salary");

                    b.Property<int>("MinSalary")
                        .HasColumnType("int")
                        .HasColumnName("min_salary");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_jobs");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("1105117d-ed96-4206-bd43-0e13b7342770"),
                            Code = "101",
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4732),
                            MaxSalary = 7500000,
                            MinSalary = 5000000,
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4733),
                            Name = "Financial Analyst"
                        },
                        new
                        {
                            Guid = new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
                            Code = "601",
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4736),
                            MaxSalary = 8000000,
                            MinSalary = 6000000,
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4736),
                            Name = "Software Developer"
                        },
                        new
                        {
                            Guid = new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
                            Code = "701",
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4739),
                            MaxSalary = 7000000,
                            MinSalary = 5000000,
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4739),
                            Name = "Recruitment Specialist"
                        });
                });

            modelBuilder.Entity("API.Models.JobHistory", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<Guid>("EmployeeGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("employee_guid");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("end_date");

                    b.Property<Guid>("JobGuid")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("job_guid");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date");

                    b.HasKey("Guid");

                    b.HasIndex("EmployeeGuid");

                    b.HasIndex("JobGuid");

                    b.ToTable("job_history");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("9942b924-53cd-4c27-9ca3-e46bca92b75a"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4126),
                            EmployeeGuid = new Guid("03e53d0a-09fe-42d3-80eb-3a80339f679d"),
                            JobGuid = new Guid("1105117d-ed96-4206-bd43-0e13b7342770"),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4127),
                            StartDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Guid = new Guid("17fe41e0-8f89-4dd9-b428-0df82f511eb5"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4137),
                            EmployeeGuid = new Guid("0c05eaec-3052-40b2-badd-8e69153a8c50"),
                            EndDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            JobGuid = new Guid("25abd2bc-c0fe-411a-ba24-f26cbae523c2"),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4137),
                            StartDate = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Guid = new Guid("5c3d8c03-561d-48f4-815e-6a5517ff9cd5"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4150),
                            EmployeeGuid = new Guid("5bc27f65-a3ec-41cf-a1a7-701b4b674653"),
                            JobGuid = new Guid("a3b9dd56-768a-45f7-99e1-8b42e9c8847f"),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 28, 189, DateTimeKind.Local).AddTicks(4150),
                            StartDate = new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("guid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_date");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("modified_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("name");

                    b.HasKey("Guid");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("tb_roles");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("aad98c8c-c71e-46f4-99c1-2d073ecb467f"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4762),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4763),
                            Name = "Staff"
                        },
                        new
                        {
                            Guid = new Guid("8d1da011-8574-4be4-9f64-657254f764d6"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4766),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4766),
                            Name = "Manager"
                        },
                        new
                        {
                            Guid = new Guid("aca8df20-f7d1-464c-947a-b22bc96c2394"),
                            CreatedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4769),
                            ModifiedDate = new DateTime(2023, 11, 28, 18, 20, 27, 314, DateTimeKind.Local).AddTicks(4769),
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.HasOne("API.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("API.Models.Account", "Guid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.HasOne("API.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("API.Models.Department", b =>
                {
                    b.HasOne("API.Models.Employee", "Manager")
                        .WithOne("DepartmentManaged")
                        .HasForeignKey("API.Models.Department", "ManagerGuid")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.HasOne("API.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Job", "Job")
                        .WithMany("Employees")
                        .HasForeignKey("JobGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("API.Models.JobHistory", b =>
                {
                    b.HasOne("API.Models.Employee", "Employee")
                        .WithMany("JobHistories")
                        .HasForeignKey("EmployeeGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Job", "Job")
                        .WithMany("JobHistories")
                        .HasForeignKey("JobGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("API.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("DepartmentManaged");

                    b.Navigation("JobHistories");
                });

            modelBuilder.Entity("API.Models.Job", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("JobHistories");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
