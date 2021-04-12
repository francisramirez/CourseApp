using CourseAdmin.Domain.Entities;
using CourseAdmin.Respository.Interfaces;
using CourseAdmin.Respository.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CourseAdmin.Respository.Context;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
namespace CourseAdmin.Respository.Repositories
{
    public class InstructorReprository : IInstructorReprository
    {
        private readonly SchoolContext _school;
        private string connstring;

        public InstructorReprository(SchoolContext school, IConfiguration configuration)
        {
            _school = school;
            this.connstring = configuration.GetConnectionString("SchoolContext");
        }
        public async Task AddInstructor(Instructor instructor)
        {
            try
            {
                Person newPerson = new Person()
                {
                    EnrollmentDate = null,
                    Discriminator = Discriminator.Instructor.ToString(),
                    FirstName = instructor.FirstName,
                    HireDate = instructor.HireDate,
                    LastName = instructor.LastName
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

        public async Task<string> AddInstructorWithProc(Instructor instructor)
        {
            string result = string.Empty;

            try
            {

                using (SqlConnection connection = new SqlConnection(this.connstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "dbo.AddInstructor";

                        var parameters = new List<SqlParameter>()
                    {
                         new SqlParameter("@LastName",instructor.LastName){ SqlDbType= SqlDbType.VarChar},
                         new SqlParameter("@FirstName", instructor.FirstName){SqlDbType=SqlDbType.VarChar},
                         new SqlParameter("@HireDate", instructor.HireDate){SqlDbType= SqlDbType.DateTime},
                         new SqlParameter("@EnrollmentDate",instructor.EnrollmentDate){SqlDbType= SqlDbType.DateTime},
                         new SqlParameter("@Discriminator",instructor.Discriminator){SqlDbType=SqlDbType.VarChar},
                         new SqlParameter("@CourseId", instructor.CourseId){SqlDbType= SqlDbType.Int},
                         new SqlParameter("@P_Result", SqlDbType.VarChar,500){ Direction= ParameterDirection.Output}
                    };


                        parameters.ForEach(parameter => command.Parameters.Add(parameter));

                        await command.ExecuteNonQueryAsync(); // DML(PROCEDURE INSERT, UPDATE, DELETE)

                        result = Convert.ToString(command.Parameters["@P_Result"].Value);
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return result;
        }

        public List<InstructorCourse> GetInstructorCourses()
        {
            try
            {
                var instructors = _school.ViewInstructors.Select(cd => new InstructorCourse()
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

        public List<InstructorCourse> GetInstructorCourses(int courseId, DateTime startDate, DateTime endDate)
        {
            List<InstructorCourse> InstructorCourse = null;
            try
            {

                using (SqlConnection connection = new SqlConnection(this.connstring))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "dbo.GetInstructors";

                        var parameters = new List<SqlParameter>()
                            {
                                 new SqlParameter("@CourseId",courseId){ SqlDbType= SqlDbType.Int},
                                 new SqlParameter("@StartDate", startDate){SqlDbType=SqlDbType.Date},
                                 new SqlParameter("@EndDate", endDate){SqlDbType= SqlDbType.Date}
                            };

                        parameters.ForEach(parameter => command.Parameters.Add(parameter));

                        var result = command.ExecuteReader();

                        if (result.HasRows)
                        {
                            InstructorCourse = new List<InstructorCourse>();

                            while (result.Read())
                            {
                                InstructorCourse.Add(new Model.InstructorCourse()
                                {
                                    InstructorId = result.GetFieldValue<int>(0),
                                    FirstName = result.GetFieldValue<string>(1),
                                    LastName = result.GetFieldValue<string>(2),
                                    HireDate = result.GetFieldValue<DateTime>(3),
                                    Course = result.GetFieldValue<string>(5),
                                });
                            }
                        }

                        result.Close();

                        return InstructorCourse;


                    }
                }



                //var instructors =

                //_school.ViewInstructors.Where(cd => cd.CourseId == courseId
                //                                                && cd.HireDate.Value.Date >= startDate.Date
                //                                                && cd.HireDate.Value.Date <= endDate.Date)
                //                                        .Select(cd => new InstructorCourse()
                //                                        {
                //                                            Course = cd.Course,
                //                                            FirstName = cd.FirstName,
                //                                            HireDate = cd.HireDate,
                //                                            InstructorId = cd.InstructorId,
                //                                            LastName = cd.LastName
                //                                        }).ToList();



                ///return instructors;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
