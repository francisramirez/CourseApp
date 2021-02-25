
using CourseAdmin.Domain.Entities;
using System.Collections.Generic;
 

namespace CourseAdmin.Respository.Interfaces
{
    public interface IDepartmentRepository : IBaseRepository<Department>
    {
        IEnumerable<Department> GetDepartmests();
    }
}
