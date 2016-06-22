using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HRManagement.Controllers
{
    [RoutePrefix("api/reports")]
    public class ReportsController : Controller
    {
        DataAccess.HrContext dbContext;
        public ReportsController(DataAccess.HrContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: Reports
        [HttpGet]
        [Route("population2")]
        public ActionResult GetPopulation2()
        {
            var groupedByAge = dbContext.Employees.ToList().GroupBy(x => DateTime.Now.Subtract(x.DateOfBirth).TotalDays / 365);

            var model = new[] {
            new {
                Description = "18 - 24 years",
                Values = groupedByAge.Where(x => x.Key <= 24).SelectMany(x => x).Count()
            },new
            {
                Description = "25 - 30 years",
                Values = groupedByAge.Where(x => x.Key <= 30 && x.Key > 24).SelectMany(x => x).Count()
            }, new
            {
                Description = "31 - 35 years",
                Values = groupedByAge.Where(x => x.Key <= 35 && x.Key > 30).SelectMany(x => x).Count()
            }, new
            {
                Description = "30 - 35 years",
                Values = groupedByAge.Where(x => x.Key <= 35 && x.Key > 30).SelectMany(x => x).Count()
            }, new
            {
                Description = "36 - 40 years",
                Values = groupedByAge.Where(x => x.Key <= 40 && x.Key > 35).SelectMany(x => x).Count()
            }, new
            {
                Description = "41 - 50 years",
                Values = groupedByAge.Where(x => x.Key <= 50 && x.Key > 40).SelectMany(x => x).Count()
            }, new
            {
                Description = "51 - 60 years",
                Values = groupedByAge.Where(x => x.Key <= 60 && x.Key > 50).SelectMany(x => x).Count()
            }, new
            {
                Description = "above 60 years",
                Values = groupedByAge.Where(x =>x.Key > 60).SelectMany(x => x).Count()
            }
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        // GET: Reports
        [HttpGet]
        [Route("population5")]
        public ActionResult GetPopulation5()
        {
            var groupedByAge = dbContext.EmploymentInformation.ToList().GroupBy(x => DateTime.Now.Subtract(x.EmploymentDate).TotalDays / 365);

            var model = new[] {
            new {
                Description = "0-1 years",
                Values = groupedByAge.Where(x => x.Key <= 1).SelectMany(x => x).Count()
            },new
            {
                Description = "1-2",
                Values = groupedByAge.Where(x => x.Key <= 2 && x.Key > 1).SelectMany(x => x).Count()
            }, new
            {
                Description = "2-3 years",
                Values = groupedByAge.Where(x => x.Key <= 3 && x.Key > 2).SelectMany(x => x).Count()
            }, new
            {
                Description = "3-4 years",
                Values = groupedByAge.Where(x => x.Key <= 4 && x.Key > 3).SelectMany(x => x).Count()
            }, new
            {
                Description = "4-6",
                Values = groupedByAge.Where(x => x.Key <= 6 && x.Key > 4).SelectMany(x => x).Count()
            }, new
            {
                Description = "over 6 years",
                Values = groupedByAge.Where(x => x.Key > 6).SelectMany(x => x).Count()
            }
           
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        // GET: Reports
        [HttpGet]
        [Route("population3")]
        public ActionResult GetPopulation3()
        {
            var groupedBySalary = dbContext.FinancialInformation.ToList().GroupBy(x => x.Salary);

            var model = new[] {
            new {
                Description = "0-400 €",
                Values = groupedBySalary.Where(x => x.Key <= 400).SelectMany(x => x).Count()
            },new
            {
                Description = "400-800 €",
                Values = groupedBySalary.Where(x => x.Key <= 800 && x.Key > 400).SelectMany(x => x).Count()
            },new
            {
                Description = "800-1200 €",
                Values = groupedBySalary.Where(x => x.Key <= 1200 && x.Key > 800).SelectMany(x => x).Count()
            },new
            {
                Description = "above 1200 €",
                Values = groupedBySalary.Where(x => x.Key >= 1200).SelectMany(x => x).Count()
            }
            };
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [Route("population")]
        public ActionResult GetPopulation()
        {
            var data = dbContext.Positions.ToList();
            var employees = dbContext.Employees.ToList();
            var months = Enumerable.Range(1, 12);

            List<CustomTuple<int, string, int>> d = new List<CustomTuple<int, string, int>>();

            foreach (var position in data)
            {
                foreach (var month in months)
                {
                    d.Add(new CustomTuple<int, string, int>(month, position.Name.ToString(), 0));
                }
            }

            foreach (var employee in employees)
            {
                d.FirstOrDefault(x => x.Item1 == employee.EmploymentInformation.EmploymentDate.Month && x.Item2 == employee.Position.Name.ToString()).Item3 += 1;
            }

            var model = d.GroupBy(x => x.Item2).Select(x => new { ExperienceLevel = x.Key, EmploymentsPerMonth = x.OrderBy(y=>y.Item1).Select(y=>y.Item3) });

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }

    public class CustomTuple<T1, T2,T3>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public T3 Item3 { get; set; }

        public CustomTuple(T1 item1, T2 item2, T3 item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }
}