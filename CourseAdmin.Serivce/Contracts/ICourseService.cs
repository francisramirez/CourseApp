using CourseAdmin.Serivce.Core;
using CourseAdmin.Serivce.Models;
using System.Threading.Tasks;

namespace CourseAdmin.Serivce.Contracts
{
    public interface ICourseService
    {
        CourseServiceResult GetCourses();
        Task<CourseServiceResult> SaveCourse(CourseSaveModel deparment);
    }
}
