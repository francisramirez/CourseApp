using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseAdmin.Serivce.Contracts;
using CourseAdmin.Serivce.Core;
using CourseAdmin.Serivce.Models;
using CourseAdmin.Serivce.Results;
using CourseAdmin.WebUi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseAdmin.WebUi.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: DepartmentController
        public ActionResult Index()
        {
            var result = _departmentService.GetDepartments();

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

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Department department)
        {
            ServiceResult result;

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                result = await _departmentService.SaveDeparment(new DeparmentModel() 
                {
                    Administrator= department.Administrador,
                    Budget= department.Budget.Value, 
                    Name= department.Name, 
                    StartDate= department.StartDate
                });

                if (!result.success)
                {
                    ViewData["Message"] = result.message;
                    return View();
                   
                }
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            ResultDeparmentModel  resultDeparment   = (ResultDeparmentModel)(await _departmentService.GetDeparmentById(id)).Data;

            var deparmentEdit = new Department()
            {
                Administrador = resultDeparment.Administrator, 
                Budget= resultDeparment.Budget, 
                DepartmentId= resultDeparment.DepartmentId,
                Name= resultDeparment.Name, 
                StartDate= resultDeparment.StartDate,
            };


            return View(deparmentEdit);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Department department)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                var result = await _departmentService.UpdateDeparment(new DeparmentModel() 
                {
                    Administrator = department.Administrador,
                    Budget = department.Budget.Value,
                    Name = department.Name,
                    StartDate = department.StartDate,
                    DepartmentId= department.DepartmentId
                });

                if (!result.success)
                {
                    ViewData["Message"] = result.message;
                    return View();
                }

                return RedirectToAction(nameof(Index));



            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
