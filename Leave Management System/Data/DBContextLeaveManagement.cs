using Microsoft.EntityFrameworkCore;
using Leave_Management_System.Entities;
using System;
namespace Leave_Management_System.Data

{
    public class DBContextLeaveManagement : DbContext
    {
        public DBContextLeaveManagement(DbContextOptions options) : base(options)
        {
         
        }
    
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<LeaveRequests> LeaveRequests { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "Asma SGHIR", Department = "IT", JoiningDate = DateTime.Now },
                new Employee { Id = 2, FullName = "John Doee", Department = "MECA", JoiningDate = DateTime.Now },
                new Employee { Id = 3, FullName = "aLEX aLEX", Department = "Auto", JoiningDate = DateTime.Now }
                );
            modelBuilder.Entity<LeaveRequests>().HasData(
                new LeaveRequests
                {
                    Id = 1,
                    EmployeeId = 1,
                    LeaveType = LeaveType.Annual,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(5),
                    Status = LeaveStatus.Pending,
                    Reason = "Vacation",
                    CreatedAt = DateTime.Now
                },
                new LeaveRequests
                {
                    Id = 2,
                    EmployeeId = 2,
                    LeaveType = LeaveType.Sick,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(4),
                    Status = LeaveStatus.Approved,
                    Reason = "Vacation",
                    CreatedAt = DateTime.Now
                },
                new LeaveRequests
                {
                    Id = 3,
                    EmployeeId = 3,
                    LeaveType = LeaveType.Other,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(4),
                    Status = LeaveStatus.Rejected,
                    Reason = "Vacation",
                    CreatedAt = DateTime.Now
                }
                );
            ;
            ;
            ;
        }
    }
}
