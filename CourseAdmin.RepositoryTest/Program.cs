using System;
using CourseAdmin.Respository.Context;
using CourseAdmin.Domain.Entities;
using CourseAdmin.Respository.Interfaces;
using CourseAdmin.Respository.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using System.Linq;
namespace CourseAdmin.RepositoryTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var contextOptions = new DbContextOptionsBuilder<SchoolContext>()
                .UseSqlServer(@"Server=DESKTOP-77KKO12\\DEVSQLEXPRESS;Database=School;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            var miContext = new SchoolContext(contextOptions);

           

            
        }
    }
}
