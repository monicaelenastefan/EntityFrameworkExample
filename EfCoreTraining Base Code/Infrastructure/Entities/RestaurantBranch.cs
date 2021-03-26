using System.Collections.Generic;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Infrastructure.Entities
{
    public class RestaurantBranch
    {
        [Key]
        public int Id { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public bool Open { get; set; }

        public string PhoneNumber { get; set; }

        public int MangerId { get; set; }

        public virtual Manager Manager { get; set; }

        public virtual ICollection<OrderTable> OrderTables { get; set; }
    }
}