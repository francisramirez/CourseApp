using CourseAdmin.Respository.Interfaces;
using CourseAdmin.Respository.Model;
using CourseAdmin.Serivce.Contracts;
using CourseAdmin.Serivce.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseAdmin.Serivce
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorReprository _instructorRepository;
        private readonly ILogger<InstructorService> _logger;

        public InstructorService(IInstructorReprository instructorRepository, ILogger<InstructorService> logger)
        {
            _instructorRepository = instructorRepository;
            _logger = logger;
        }

        public async Task<InstructorResult> AddInstructor(Instructor instructor)
        {
            InstructorResult result = new InstructorResult();
            try
            {
                await _instructorRepository.AddInstructor(instructor);
                result.success = true;
                result.message = "Instructor agregado correctamente.";
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error agregando el instructor.";
                _logger.LogError(result.message, ex);
            }

            return result;
        }

        public InstructorResult GetInstructorCourses()
        {
            InstructorResult result = new InstructorResult();
            try
            {
                result.Data= _instructorRepository.GetInstructorCourses();
                result.success = true;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obteniendo los instructores.";
                _logger.LogError(result.message, ex);
            }
            return result;
        }

        public InstructorResult GetInstructorCourses(int courseId, DateTime startDate, DateTime endDate)
        {
            InstructorResult result = new InstructorResult();
            
            try
            {
                result.Data = _instructorRepository.GetInstructorCourses(courseId, startDate, endDate);
                result.success = true;

            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Error obteniendo los instructores.";
                _logger.LogError(result.message, ex);
            }
            return result;
        }
    }
}
