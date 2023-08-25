﻿using Infrastructure.Model;

namespace WS.Model.Dtos.Employee
{
    public class EmployeePutDto : IDto
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
    }
}
