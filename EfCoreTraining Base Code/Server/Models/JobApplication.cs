using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class JobApplication
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string Address { get; set; }

        public int EmployeeRequirementsId { get; set; }
    }
}