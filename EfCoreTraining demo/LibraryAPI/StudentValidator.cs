using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace LibraryAPI
{
    public static class StudentValidator
    {
        public static bool IsValid(Student student)
        {
            return student.Name.ToLower().Contains("test");
        }
    }
}