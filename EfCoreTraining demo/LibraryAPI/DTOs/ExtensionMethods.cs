using System.Linq;
using Models;

namespace LibraryAPI.DTOs
{
    public static class ExtensionMethods
    {
        public static StudentDTO ToDtoStudent(this Student student)
        {
            return new StudentDTO
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                FullName = student.FullName,
                Books = student.Books.Select(x => x.ToDtoBook())
            };
        }

        public static BookDto ToDtoBook(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author
            };
        }
    }
}