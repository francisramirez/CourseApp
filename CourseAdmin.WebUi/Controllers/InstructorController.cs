﻿using CourseAdmin.Respository.Model;
using CourseAdmin.Serivce.Contracts;
using CourseAdmin.Serivce.Results;
using CourseAdmin.WebUi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
namespace CourseAdmin.WebUi.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorService;
        private readonly ICourseService _courseService;

        public InstructorController(IInstructorService instructorService, ICourseService courseService)
        {
            _instructorService = instructorService;
            _courseService = courseService;
        }
        // GET: InstructorController
        public ActionResult Index()
        {
            DateTime startDate = new DateTime(2021, 3, 1);
            DateTime endDate = new DateTime(2021, 3, 29);

            var instructors = _instructorService.GetInstructorCourses(1045, startDate, endDate);

            IntructorViewModel intructorViewModel = new IntructorViewModel();

            intructorViewModel.InstructorCourses = (List<InstructorCourse>)instructors.Data;

            var courses = (List<CourseResultModel>)_courseService.GetCourses().Data;

            ViewBag.Courses = new SelectList(courses, "CourseId", "Title");

            return View(intructorViewModel);
        }

        // GET: InstructorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InstructorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstructorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Instructor instructorModel)
        {
            try
            {
                _instructorService.AddInstructor(instructorModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstructorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InstructorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: InstructorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InstructorController/Delete/5
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
