using System.Collections.Generic;
using HRManagement.DataAccess.Models.Models;

namespace HRManagement.ViewModels
{
    public class Project
    {
        public class EmployeesAssignedToProjectViewModel
        {
            public string EmployeeFirstName { get; internal set; }
            public string EmployeeLastName { get; internal set; }
            public string EmployeeMiddleName { get; internal set; }
            public int Id { get; internal set; }
        }

        public class ProjectIndexDataViewModel
        {
            public List<EmployeesAssignedToProjectViewModel> EmployeesAssignedToProjects { get; set; }
            public List<DataAccess.Models.Models.Project> Projects { get; set; }
        }
    }
}