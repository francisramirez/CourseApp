using CourseAdmin.Domain.Entities;
using CourseAdmin.Respository.Interfaces;
using CourseAdmin.Respository.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseAdmin.Respository.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CourseAdmin.Respository.Repositories
{
    public class InstructorReprository : IInstructorReprository
    {
        private readonly SchoolContext _school;

        public InstructorReprository(SchoolContext school)
        {
            _school = school;
        }
        public async Task AddInstructor(Instructor instructor)
        {
            try
            {
                Person newPerson = new Person()
                {
                    EnrollmentDate= null, 
                    Discriminator= Discriminator.Instructor.ToString(), 
                    FirstName= instructor.FirstName, 
                    HireDate= instructor.HireDate, 
                    LastName= instructor.LastName
                };

                newPerson.CourseInstructor.Add(new CourseInstructor()
                {
                    CourseId = instructor.CourseId,
                    PersonId = newPerson.PersonId
                });
                
                _school.Add(newPerson);
                
                await _school.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<InstructorCourse> GetInstructorCourses()
        {
            try
            {
                var instructors = _school.ViewInstructors.Select(cd => new InstructorCourse() 
                {
                    Course= cd.Course, 
                    FirstName= cd.FirstName, 
                    HireDate=cd.HireDate, 
                    InstructorId=cd.InstructorId, 
                    LastName=cd.LastName
                }).ToList();
                
                return instructors;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<InstructorCourse> GetInstructorCourses(int courseId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var instructors = _school.ViewInstructors.Where(cd => cd.CourseId == courseId 
                                                                && cd.HireDate.Value.Date >= startDate.Date 
                                                                && cd.HireDate.Value.Date <= endDate.Date)
                                                        .Select(cd => new InstructorCourse()
                {
                    Course = cd.Course,
                    FirstName = cd.FirstName,
                    HireDate = cd.HireDate,
                    InstructorId = cd.InstructorId,
                    LastName = cd.LastName
                }).ToList();

                return instructors;
            } 
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
