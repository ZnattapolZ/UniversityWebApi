using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using UniversityWebApi.Data;
using UniversityWebApi.Models;

namespace UniversityWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UniversityApiController : ControllerBase
    {
        private readonly UniversityContext _context;

        public UniversityApiController(UniversityContext context)
        {
            _context = context;
        }

        [Route("/universities")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<University>>> GetAllUniversities()
        {
            var results = await _context.Universities.AsNoTracking().ToListAsync();

            return Ok(results);
        }

        [Route("/universities/{universityId}")]
        [HttpGet]
        public ActionResult<Student> GetUniversityById(int? universityId)
        {
            if (universityId == null)
            {
                return NotFound();
            }

            var result = from u in _context.Universities
                         join e in _context.Enrolls on u.UniversityId equals e.UniversityId into eu
                         from e in eu.DefaultIfEmpty()
                         where u.UniversityId == universityId
                         select new
                         {
                             u.UniversityId,
                             u.Name,
                             students = (from s in _context.Students
                                        join e in _context.Enrolls on s.StudentId equals e.StudentId into es
                                        from e in es.DefaultIfEmpty()
                                        where e.UniversityId == universityId
                                        select new
                                        {
                                            s.StudentId,
                                            s.FirstName,
                                            s.LastName,
                                            e.Degree
                                        }).ToList()
                         };

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("/universities")]
        [HttpPost]
        public async Task<ActionResult> CreateUniversity(University university)
        {
            _context.Universities.Add(university);
            await _context.SaveChangesAsync();

            return Ok(university);
        }

        [Route("/universities/{universityId}")]
        [HttpPut]
        public async Task<ActionResult> UpdateUniversity(int universityId, University university)
        {
            if(universityId != university.UniversityId)
            {
                return BadRequest();
            }

            _context.Entry(university).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("/universities/{universityId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteUniversity(int universityId)
        {
            var result = await _context.Universities.FindAsync(universityId);
            if(result == null)
            {
                return NotFound();
            }

            _context.Universities.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("/students")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var results = await _context.Students.AsNoTracking().ToListAsync();
            return Ok(results);
        }

        [Route("/students/{studentId}")]
        [HttpGet]
        public ActionResult<Student> GetStudentById(int? studentId)
        {
            if (studentId == null)
            {
                return NotFound();
            }

            var result = from s in _context.Students
                         join e in _context.Enrolls on s.StudentId equals e.StudentId into es
                         from e in es.DefaultIfEmpty()
                         where s.StudentId == studentId
                         select new
                         {
                             s.StudentId,
                             s.FirstName,
                             s.LastName,
                             universities = (from u in _context.Universities
                                             join e in _context.Enrolls on u.UniversityId equals e.UniversityId into eu
                                             from e in eu.DefaultIfEmpty()
                                             where e.StudentId == studentId
                                             select new
                                             {
                                                 u.Name
                                             }).ToList()
                         };

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("/students")]
        [HttpPost]
        public async Task<ActionResult> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        }

        [Route("/students/{studentId}")]
        [HttpPut]
        public async Task<ActionResult> UpdateStudent(int studentId, Student student)
        {
            if (studentId != student.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("/students/{studentId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteStudent(int studentId)
        {
            var result = await _context.Students.FindAsync(studentId);
            if (result == null)
            {
                return NotFound();
            }

            _context.Students.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("/enrolls")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllEnrollments()
        {
            var results = await _context.Enrolls.AsNoTracking().ToListAsync();

            return Ok(results);
        }

        [Route("/enrolls/{enrollId}")]
        [HttpGet]
        public async Task<ActionResult<Enroll>> GetEnrollmentById(int? enrollId)
        {
            if (enrollId == null)
            {
                return NotFound();
            }

            var result = await _context.Enrolls.AsNoTracking().FirstOrDefaultAsync(x => x.EnrollId == enrollId);


            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [Route("/enrolls")]
        [HttpPost]
        public async Task<ActionResult> CreateEnrollment(Enroll enroll)
        {
            _context.Enrolls.Add(enroll);
            await _context.SaveChangesAsync();

            return Ok(enroll);
        }

        [Route("/enrolls/{enrollId}")]
        [HttpPut]
        public async Task<ActionResult> UpdateEnrollment(int enrollId, Enroll enroll)
        {
            if (enrollId != enroll.EnrollId)
            {
                return BadRequest();
            }

            _context.Entry(enroll).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [Route("/enrolls/{enrollId}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteEnrollment(int enrollId)
        {
            var result = await _context.Enrolls.FindAsync(enrollId);
            if (result == null)
            {
                return NotFound();
            }

            _context.Enrolls.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}