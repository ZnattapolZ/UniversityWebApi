using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityWebApi.Data;

namespace UniversityWebApi.Models
{
    public static class DbInitializer
    {
        public static void Initialize(UniversityContext context)
        {
            context.Database.EnsureCreated();
            if(context.Students.Any() && context.Universities.Any() && context.Enrolls.Any())
            {
                return;
            }

            context.Universities.AddRange(
                new University
                {
                    UniversityId = 1,
                    Name = "MU"
                },
                new University
                {
                    UniversityId = 2,
                    Name = "CU"
                },
                new University
                {
                    UniversityId = 3,
                    Name = "KMUTT"
                });

            context.Students.AddRange(
                new Student
                {
                    StudentId = 6013110,
                    FirstName = "Annie",
                    LastName = "Ant"
                },
                new Student
                {
                    StudentId = 6013111,
                    FirstName = "Brownie",
                    LastName = "Bee"
                },
                new Student
                {
                    StudentId = 6013112,
                    FirstName = "Catie",
                    LastName = "Cat"
                });

            context.Enrolls.AddRange(
                new Enroll
                {
                    Degree = "Bachelor",
                    StudentId = 6013110,
                    UniversityId = 1
                },
                new Enroll
                {
                    Degree = "Bachelor",
                    StudentId = 6013111,
                    UniversityId = 1
                },
                new Enroll
                {
                    Degree = "Master",
                    StudentId = 6013111,
                    UniversityId = 2
                },
                new Enroll
                {
                    Degree = "Bachelor",
                    StudentId = 6013112,
                    UniversityId = 3
                });
            context.SaveChanges();
        }
    }
}
