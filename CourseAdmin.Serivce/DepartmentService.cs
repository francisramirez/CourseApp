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
using Microsoft.Extensions.Configuration;

namespace CourseAdmin.Serivce
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly ILogger<DepartmentService> _logger;
        private readonly IConfiguration _configuration;

        public DepartmentService(IDepartmentRepository departmentRepository, 
                                 ILogger<DepartmentService> logger, 
                                 IConfiguration configuration)
        {
            _departmentRepository = departmentRepository;
            _logger = logger;
            _configuration = configuration;
        }
                
        public async  Task<DeparmentServiceResult> GetDeparmentById(int Id)
        {
            DeparmentServiceResult result = new DeparmentServiceResult();
            try
            {
                var deptoFound = await _departmentRepository.GetById(Id);
                
                result.Data = new ResultDeparmentModel()
                {
                     Administrator = deptoFound.Administrator,
                    Budget = deptoFound.Budget,
                    DepartmentId = deptoFound.DepartmentId,
                    Name = deptoFound.Name,
                    StartDate = deptoFound.StartDate.ToString("MM/dd/yyyy")
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}", ex);
                //sendEmail
                result.success = false;
                result.message = "Error obteniendo los departamentos";
            }
            return result;
        }

        public DeparmentServiceResult GetDepartments()
        {
            DeparmentServiceResult result = new DeparmentServiceResult();

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

        public async Task<DeparmentServiceResult> RemoveDepartment(DepartmentRemoveModel departmentRemove)
        {
            DeparmentServiceResult serviceResult = new DeparmentServiceResult();
            try
            {
                Department department = await this._departmentRepository.GetById(departmentRemove.DepartmentId);
                
                department.Deleted = true;
                department.UserDeleted = departmentRemove.UserDeleted;
                department.DeletedDate = DateTime.Now;

                _departmentRepository.Update(department);
                await _departmentRepository.Commit();

                serviceResult.success = true;
                serviceResult.message = _configuration["Mensajes:MensajeEliminado"];
            }
            catch (Exception ex)
            {
                serviceResult.success = false;
                serviceResult.message = _configuration["Mensajes:MensajeErrorEliminado"];
                _logger.LogError(serviceResult.message, ex);

            }
            return serviceResult;
        }

        public async Task<DeparmentServiceResult> SaveDeparment(DeparmentModel deparment)
        {
            DeparmentServiceResult result = new DeparmentServiceResult();

            try
            {
                if (await ValidateDeparmentName(deparment.Name))
                {
                    result.success = false;
                    result.message = $"Este departamento: {deparment.Name} ya esta registrado.";
                    return result;
                }


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

        public async Task<DeparmentServiceResult> UpdateDeparment(DepartmentModifyModel deparment)
        {
            DeparmentServiceResult result = new DeparmentServiceResult();

            try
            {
                var deptUpdated = await _departmentRepository.GetById(deparment.DepartmentId);
                             

                deptUpdated.Administrator = deparment.Administrator;
                deptUpdated.Budget = deparment.Budget;
                deptUpdated.ModifyDate = DateTime.Now;
                deptUpdated.UserMod = 1;
                deptUpdated.Name = deparment.Name;
                deptUpdated.StartDate = Convert.ToDateTime(deparment.StartDate);
              

                _departmentRepository.Update(deptUpdated);

                await _departmentRepository.Commit();

                result.message = "Departamento acutalizado correctamente.";
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error: {ex.Message}", ex);
                result.success = false;
                result.message = "Error agregando la informacion del departamento";
            }
            return result;
        }

        private async Task<bool> ValidateDeparmentName(string name) 
        {
            return await _departmentRepository.Exists(cd => cd.Name == name);
        }
    }
}
