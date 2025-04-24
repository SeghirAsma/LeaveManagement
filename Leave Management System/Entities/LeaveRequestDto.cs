﻿namespace Leave_Management_System.Entities
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeDepartment { get; set; }
        public string? LeaveType { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
        
    }
}
