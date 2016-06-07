using System.Collections.Generic;
using System.Linq;

namespace HRManagement.ViewModels.Employee
{
    public class EmployeeIndexViewModel
    {
        public List<DataAccess.Models.Models.Employee> Employees { get; set; }
        public IQueryable<DataAccess.Models.Models.Training> Trainings { get; set; }
        public EmployeeAssignTrainingTrigger EmployeeAssignTrainingsTrigger { get; set; }
    }
}