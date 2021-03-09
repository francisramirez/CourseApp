using CourseAdmin.Domain.Entities;
using CourseAdmin.Serivce.Models;

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
    }
}
