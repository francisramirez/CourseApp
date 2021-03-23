using CourseAdmin.Serivce.Contracts;
using CourseAdmin.Serivce.Core;
using CourseAdmin.Serivce.Models;
using CourseAdmin.Respository.Interfaces;
using Microsoft.Extensions.Logging;
using CourseAdmin.Serivce.Results;
using CourseAdmin.Serivce.Extentions;
using System;
using System.Linq;
using System.Threading.Tasks;
using CourseAdmin.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace CourseAdmin.Serivce
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<CourseService> _looger;
        private readonly IConfiguration _configuration;

        public CourseService(ICourseRepository courseRepository, 
            IDepartmentRepository departmentRepository,
            ILogger<CourseService> looger, IConfiguration configuration)
        {
            _courseRepository = courseRepository;
            _departmentRepository = departmentRepository;
            _looger = looger;
            _configuration = configuration;
        }

        public async Task<CourseServiceResult> GetCourseInfoById(int courseId)
        {
            CourseServiceResult result = new CourseServiceResult();
            try
            {
                result.Data = (await _courseRepository.GetById(courseId)).ConvertCourseResultModelFromCourse();
                result.success = true;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = _configuration["MensajesCourse:MensajeErrorGet"];
                _looger.LogError(result.message, ex);
            }

            return result;
        }
        public CourseServiceResult GetCourses()
        {
            CourseServiceResult result = new CourseServiceResult();
            try
            {

                var query = (from course in _courseRepository.FindAll(course => !course.Deleted)
                             join depto in _departmentRepository.FindAll(dep => !dep.Deleted) on course.DepartmentId equals depto.DepartmentId
                             select new CourseResultModel
                             {
                                 CourseId = course.CourseId,
                                 Credits = course.Credits,
                                 DepartmentId = course.DepartmentId,
                                 DepartmentName = depto.Name,
                                 Title = course.Title
                             }).ToList();

                result.Data = query;

                result.success = true;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = _configuration["MensajesCourse:MensajeErrorGet"];
                _looger.LogError(result.message, ex);
            }
            return result;
        }
        public async Task<CourseServiceResult> ModifyCourse(CourseModify courseModify)
        {
            CourseServiceResult result = new CourseServiceResult();
            try
            {
                Course courseMod = await _courseRepository.GetById(courseModify.CourseId);

                courseMod.Title = courseModify.Title;
                courseMod.Credits = courseModify.Credits;
                courseMod.ModifyDate = DateTime.Now;
                courseMod.UserMod = courseModify.UserMod;

                _courseRepository.Update(courseMod);

               await _courseRepository.Commit();

                result.message = "Curso modificado correctamente.";
              
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Ocurrió un error modificando el curso.";
                _looger.LogError(result.message, ex);

            }
            return result;
        }
        public async Task<CourseServiceResult> SaveCourse(CourseSaveModel deparment)
        {
            CourseServiceResult result = new CourseServiceResult();

            try
            {
               Course newCourse = deparment.ConvertCourseSaveModeToCourse();
               
                await _courseRepository.Add(newCourse);
                await _courseRepository.Commit();

                result.message = _configuration["MensajesCourse:MensajeSaveOk"];
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = _configuration["MensajesCourse:MensajeErrorSave"];
                _looger.LogError(result.message, ex); throw;
            }
            return result;
        }
    }
}
