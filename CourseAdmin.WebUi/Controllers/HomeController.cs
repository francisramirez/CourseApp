using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CourseAdmin.WebUi.Models;
using CourseAdmin.Respository.Context;
using CourseAdmin.Serivce.Contracts;
using CourseAdmin.Serivce.Results;

namespace CourseAdmin.WebUi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public HomeController(IDepartmentService departmentService)
        {
           _departmentService = departmentService;
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
            var result = this._departmentService.GetDepartments();

            var departaments = ((List<ResultDeparmentModel>)result.Data).Select(dep => new Department() 
            {
                Administrador = dep.Administrator,
                Budget = dep.Budget,
                DepartmentId = dep.DepartmentId,
                StartDate = dep.StartDate,
                Name = dep.Name

            }).ToList();

            return View(departaments);
        }

        public IActionResult Course() {
            return View();
        }
    }
}
