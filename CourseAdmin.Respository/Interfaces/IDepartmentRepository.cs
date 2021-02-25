
using CourseAdmin.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseAdmin.Respository.Interfaces
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartmests();
    }
}
