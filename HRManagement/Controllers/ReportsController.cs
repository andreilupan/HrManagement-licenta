using System;
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
            var model = new[] { new
            {
                City = "Satu Mare",
                PopulationPerMonth = new[] {
                    12.4,
                    23.5,
                    32.9,
                    43.5,
                    12.4,
                    43.6,
                    22.4,
                    23.2,
                    22.4,
                    33.1,
                    12.0,
                    23.5
                }
            },
            new {
                City = "Cluj",
                PopulationPerMonth = new[] {
                    32.9,
                    43.6,
                    22.4,
                    23.2,
                    22.4,
                    12.4,
                    12.4,
                    23.5,
                    33.1,
                    43.5,
                    12.0,
                    23.5,

                }
            },
            new {
                City = "Baia Mare",
                PopulationPerMonth = new[] {
                    12.4,
                    23.5,
                    43.5,
                    43.6,
                    12.4,
                    22.4,
                    23.2,
                    23.5,
                        22.4,
                    33.1,
                    32.9,
                    12.0,
                }
            }
            };


            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}