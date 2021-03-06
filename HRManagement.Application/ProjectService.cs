﻿using HRManagement.DataAccess.Models.Models;
using HRManagement.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application
{
   public class ProjectService : IProjectService
    {
        private IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public List<Project> GetAllProjects()
        {
            return _projectRepository.GetAllProjects().ToList();
        }
        List<ViewModels.Project.EmployeesAssignedToProjectViewModel> IProjectService.GetEmployeesForProject(int? id)
        {
            var projectEmployees = _projectRepository.GetProjectById(id).Employees;

            return projectEmployees.Select(x => new ViewModels.Project.EmployeesAssignedToProjectViewModel
            {
                Id = x.Id,
                EmployeeFirstName = x.FirstName,
                EmployeeLastName = x.LastName,
                EmployeeMiddleName = x.MiddleName
            }).ToList();
        }
    }
}
