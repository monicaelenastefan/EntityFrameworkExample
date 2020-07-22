using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure;
using LibraryAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly DatabaseContext _context;


        public StudentController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IList<StudentDTO> Get()
        {
            //var allStudents = GetValidStudentsWrongWay();
            var allStudents = GetStudentsWithExplicitLoading().Select(x => x.ToDtoStudent());

            return allStudents.ToList();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var student = _context.Students.Include(x => x.Books).Single(x => x.Id == id);
            _context.Students.Remove(student);

            _context.SaveChanges();
        }

        private IEnumerable<StudentDTO> GetValidStudentsWrongWay()
        {
            return _context.Students.Where(
                    x => x.Name.Length > 2 &&
                         StudentValidator.IsValid(x))
                .Select(x => x.ToDtoStudent());
        }

        private IEnumerable<Student> GetStudentsWithBooksEagerLoading()
        {
            var students = _context.Students.Include(x => x.Books);

            return students;
            //include multiple levels
        }

        private IEnumerable<Student> GetStudentsWithLazyLoading()
        {
            var students = _context.Students.ToList();

            return students;
            //include multiple levels
        }

        private IEnumerable<Student> GetStudentsWithExplicitLoading()
        {
            var student = _context.Students.First();

            _context.Entry(student).Collection(x => x.Books).Load();


            return new List<Student> {student};
        }

        private IEnumerable<StudentDTO> GetValidStudentsRightWay()
        {
            return _context.Students.Where(x => x.Name.Length > 2).AsEnumerable()
                .Where(x => StudentValidator.IsValid(x))
                .Select(x => x.ToDtoStudent());
        }

        private StudentDTO GetStudentByIdForEach(int id)
        {
            foreach (var student in _context.Students)
            {
                if (student.Id == id)
                {
                    return student.ToDtoStudent();
                }
            }

            return null;
        }

        private StudentDTO GetStudentByIdLinq(int id)
        {
            return _context.Students.SingleOrDefault(x => x.Id == id).ToDtoStudent();
        }

        private IEnumerable<Student> GetStudentByNameLinqSQL(string name)
        {
            return (from student in _context.Students where student.Name == name select student);
            return _context.Students.Where(x => x.Name == name);
        }
    }
}