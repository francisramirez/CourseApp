using System;
using System.Linq;
using CourseAdmin.Serivce.Contracts;
using CourseAdmin.Serivce.Core;
using CourseAdmin.Serivce.Models;
using CourseAdmin.Serivce.Results;
using CourseAdmin.Respository.Interfaces;
using CourseAdmin.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CourseAdmin.Serivce
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DepartmentService> _logger;

        public DepartmentService(IDepartmentRepository departmentRepository, ILogger<DepartmentService> logger)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
        }
        public ServiceResult GetDepartments()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = _departmentRepository.FindAll(dep => !dep.Deleted).Select(dep => new ResultDeparmentModel()
                {
                    Administrator = dep.Administrator,
                    Budget = dep.Budget,
                    DepartmentId = dep.DepartmentId,
                    StartDate = dep.StartDate.ToString("dd/MM/yyyy"),
                    Name = dep.Name
                }).ToList();

                

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}", ex);
                result.success = false;
                result.message = "Error obteniendo los departamentos";
            }
            return result;
        }

        public async Task<ServiceResult> SaveDeparment(DeparmentModel deparment)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                Department newDepartment = new Department()
                {
                    Administrator = deparment.Administrator,
                    Budget = deparment.Budget,
                    Name = deparment.Name,
                    StartDate = Convert.ToDateTime(deparment.StartDate),
                };

                await _departmentRepository.Add(newDepartment);

                result.message = await _departmentRepository.Commit() ? "Department Agregado" : "Error agregando el departamento";

                deparment.DepartmentId = newDepartment.DepartmentId;

                result.Data = deparment;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}", ex);
                result.success = false;
                result.message = "Error agregando la informacion del departamento";
            }
            return result;
        }
    }
}
