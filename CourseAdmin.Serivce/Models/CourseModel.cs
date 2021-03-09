
namespace CourseAdmin.Serivce.Models
{
    public class CourseSaveModel
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public int CreationUser { get; set; }
    }
}
