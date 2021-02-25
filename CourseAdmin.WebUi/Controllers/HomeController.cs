using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseAdmin.WebUi.Models;
using CourseAdmin.Respository.Context;

namespace CourseAdmin.WebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext schoolContext;

        public HomeController(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Department() 
        {
            var departments = this.schoolContext.Department.Select(cd => new Models.Department() 
            {
                DepartmentId= cd.DepartmentId, 
                Administrador= cd.Administrator, 
                Budget= cd.Budget, 
                Name= cd.Name, 
                StartDate= cd.StartDate
            }).ToList();

            return View(departments);
        }

        public IActionResult Course() {
            return View();
        }
    }
}
