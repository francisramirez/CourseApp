using CourseAdmin.Domain.Entities;
using CourseAdmin.Serivce.Models;
using CourseAdmin.Serivce.Results;

namespace CourseAdmin.Serivce.Extentions
{
    public static class CourseExtention
    {
        public static Course ConvertCourseSaveModeToCourse(this CourseSaveModel courseSaveModel) 
        {
            return new Course() 
            {
                Title= courseSaveModel.Title, 
                DepartmentId= courseSaveModel.DepartmentId, 
                CreationUser= courseSaveModel.CreationUser,
                Credits= courseSaveModel.Credits  
            };
        }
        public static CourseResultModel ConvertCourseResultModelFromCourse(this Course course)
        {
            return new CourseResultModel()
            {
                CourseId= course.CourseId,
                Title = course.Title,
                DepartmentId = course.DepartmentId,
                Credits = course.Credits
            };
        }
    }
}
