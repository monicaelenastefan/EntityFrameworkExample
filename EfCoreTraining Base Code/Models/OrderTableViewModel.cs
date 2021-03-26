﻿using System;

namespace Models
{
    public class OrderTableViewModel
    {
        
        public int Id { get; set; }

       
        public string FirstName { get; set; }

      
        public string LastName { get; set; }

     
        public string PhoneNumber { get; set; }

    
        public DateTime ReservationTime { get; set; }

        public int DinnerGuests { get; set; }

        public int RestaurantBranchId { get; set; }
       
    }


}