using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CourseAdmin.Serivce.Contracts;
using CourseAdmin.WebUi.Models;
using CourseAdmin.Serivce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using CourseAdmin.Serivce.Results;
using System.Linq;
using CourseAdmin.WebUi.ViewModels;

namespace CourseAdmin.WebUi.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IDepartmentService _departmentService;

        public CourseController(ICourseService courseService, IDepartmentService departmentService)
        {
            _courseService = courseService;
            _departmentService = departmentService;
        }

        [HttpPost]
        public async Task<IActionResult> GetCourseInfo(int courseId)
        {
            var CourseResult = await _courseService.GetCourseInfoById(courseId);

            return Ok(CourseResult);
        }

        [HttpPost]
        public async Task<IActionResult> Modify(CourseModelModify courseModify) 
        {
            CourseModify courseMod = new CourseModify()
            {
                CourseId= courseModify.CourseId, 
                UserMod=1,
                Credits= courseModify.Credits, 
                DepartmentId= courseModify.DepartmentId, 
                Title= courseModify.Title
            };

            var result = await _courseService.ModifyCourse(courseMod);

            return Ok(result);
        }


        
        public ActionResult Index()
        {
            var courses = (List<CourseResultModel>)_courseService.GetCourses().Data;

            var resultDepartment = _departmentService.GetDepartments().Data;

            var departaments = ((List<ResultDeparmentModel>)resultDepartment).Select(dep => new DepartmentViewModel()
            {
                DepartmentId = dep.DepartmentId,
                Name = dep.Name
            }).ToList();

            ViewBag.DepartmentList = new SelectList(departaments, "DepartmentId", "Name");

            CourseViewModel courseViewModel = new CourseViewModel()
            {
                  CourseList= courses.Select(cd => new CourseList() 
                  {
                      CourseId= cd.CourseId, 
                      Credits=cd.Credits, 
                      DepartmentName= 
                      cd.DepartmentName, 
                      Title= cd.Title
                  }).ToList()
            };
            
            return View(courseViewModel);
        }

        
        public ActionResult Details(int id)
        {
            return View();
        }

        
        public ActionResult Create()
        {
            var resultDepartment = _departmentService.GetDepartments().Data;

            var departaments = ((List<ResultDeparmentModel>)resultDepartment).Select(dep => new DepartmentViewModel()
            {
                DepartmentId = dep.DepartmentId,
                Name = dep.Name
            }).ToList();

            ViewBag.DepartmentList = new SelectList(departaments, "DepartmentId", "Name");

            return View();
        }

        [HttpPost]
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

                return Ok(CourseServiceResult);
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
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
