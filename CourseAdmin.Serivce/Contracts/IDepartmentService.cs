using CourseAdmin.Serivce.Core;
using System.Threading.Tasks;

namespace CourseAdmin.Serivce.Contracts
{
    public interface IDepartmentService
    {
      ServiceResult GetDepartments();
      Task<ServiceResult> SaveDeparment(Models.DeparmentModel deparment);
       
    }
}
