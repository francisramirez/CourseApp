using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CourseAdmin.Serivce.Contracts;
using CourseAdmin.WebUi.Models;
using CourseAdmin.Serivce.Models;
using CourseAdmin.Serivce.Core;
using System.Threading.Tasks;

namespace CourseAdmin.WebUi.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        // GET: CourseController
        public ActionResult Index()
        {
            var courses = _courseService.GetCourses();

            return View(courses.Data);
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Course course)
        {
            try
            {
                CourseSaveModel courseSaveModel = new CourseSaveModel()
                {
                    CreationUser=1, 
                    Credits= course.Credits, 
                    DepartmentId= course.DepartmentId, 
                    Title= course.Title
                };

                var CourseServiceResult = await _courseService.SaveCourse(courseSaveModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
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

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourseController/Delete/5
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
