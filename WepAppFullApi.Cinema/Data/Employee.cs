﻿namespace WepAppFullApi.Cinema.Data
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsDeleted { get; set; } = false;
        public List<ProjectionActivity>? ProjectionActivities { get; set; }
    }
}
