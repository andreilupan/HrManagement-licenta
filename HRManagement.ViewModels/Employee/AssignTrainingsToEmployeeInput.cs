using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModels.Employee
{
  public class AssignTrainingsToEmployeeInput
    {
        public int EmployeeId { get; set; }
        public List<AssignTrainingsToEmployeeListItem> Trainings { get; set; }
    }
}
