using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace Infrastructure.Entities
{
    public class OrderTable 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(12)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(12)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReservationTime { get; set; }

        public int DinnerGuests { get; set; }

        public int RestaurantBranchId { get; set; }
        public virtual RestaurantBranch RestaurantBranch { get; set; }

        public virtual ICollection<WaiterOrderTable> WaiterOrderTables { get; set; }
    }

   
}