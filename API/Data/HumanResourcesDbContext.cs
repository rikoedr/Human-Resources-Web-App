using API.Models;
using API.Utilities.SampleData;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class HumanResourcesDbContext : DbContext
{
    public HumanResourcesDbContext(DbContextOptions<HumanResourcesDbContext> options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Job> Jobs { get; set; }

    // Database design
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Set Constraint
        modelBuilder.Entity<Account>().HasIndex(a => a.Email).IsUnique();
        modelBuilder.Entity<Employee>().HasIndex(e => e.PhoneNumber).IsUnique();
        modelBuilder.Entity<Department>().HasIndex(e => e.Name).IsUnique();
        modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique();
        modelBuilder.Entity<Job>().HasIndex(j => j.Name).IsUnique();
        modelBuilder.Entity<Department>().HasIndex(d => d.Code).IsUnique();

        // Set Cardinality
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Account)
            .WithOne(a => a.Employee)
            .HasForeignKey<Account>(a => a.Guid);

        modelBuilder.Entity<Account>()
            .HasMany(a => a.AccountRoles)
            .WithOne(ar => ar.Account)
            .HasForeignKey(ar => ar.AccountGuid);

        modelBuilder.Entity<Role>()
            .HasMany(r => r.AccountRoles)
            .WithOne(ar => ar.Role)
            .HasForeignKey(ar => ar.RoleGuid);

        modelBuilder.Entity<Department>()
            .HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentGuid);

        modelBuilder.Entity<Department>()
            .HasOne(d => d.Manager)
            .WithOne(e => e.DepartmentManaged)
            .HasForeignKey<Department>(d => d.ManagerGuid)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Job>()
            .HasMany(j => j.Employees)
            .WithOne(e => e.Job)
            .HasForeignKey(e => e.JobGuid);

        modelBuilder.Entity<Employee>()
            .HasMany(e => e.JobHistories)
            .WithOne(jh => jh.Employee)
            .HasForeignKey(e => e.EmployeeGuid);

        modelBuilder.Entity<Job>()
            .HasMany(j => j.JobHistories)
            .WithOne(jh => jh.Job)
            .HasForeignKey(jh => jh.JobGuid)
            .OnDelete(DeleteBehavior.NoAction);

        // Insert Sample Data
        insertSampleData(modelBuilder);
    }

    private void insertSampleData(ModelBuilder modelBuilder)
    {
        // Department sample data
        modelBuilder.Entity<Department>().HasData(
            DepartmentSample.Finance(),
            DepartmentSample.InformationTechnology(),
            DepartmentSample.HumanResources()
        );

        // Job sample data
        modelBuilder.Entity<Job>().HasData(
            JobSample.FinancialAnalyst(),
            JobSample.SoftwareDeveloper(),
            JobSample.RecruitmentSpecialist()
        );

        // Role sample data
        modelBuilder.Entity<Role>().HasData(
            RoleSample.Staff(),
            RoleSample.Manager(),
            RoleSample.Admin()
        );

        // Employee sample data
        modelBuilder.Entity<Employee>().HasData(
            EmployeeSample.JohnDoe(),    
            EmployeeSample.JaneSmith(),    
            EmployeeSample.BobJohnson()
        );

        // Account sample data
        modelBuilder.Entity<Account>().HasData(
            AccountSample.JohnDoe(),
            AccountSample.JaneSmith(),
            AccountSample.BobJohnson()
        );

        // Account role sample data
        modelBuilder.Entity<AccountRole>().HasData(
            AccountRoleSample.JohnDoe(),
            AccountRoleSample.JaneSmith(),
            AccountRoleSample.BobJohnson()
        );

        // Job history sample data
        modelBuilder.Entity<JobHistory>().HasData(
            JobHistorySample.JohnDoe(),
            JobHistorySample.JaneSmith(),
            JobHistorySample.BobJohnson()
        );
    }
}
