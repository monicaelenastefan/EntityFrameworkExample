namespace Infrastructure.Entities
{
    public class Manager
    {
        public int ManagerId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public virtual RestaurantBranch RestaurantBranch { get; set; }
       
    }
}