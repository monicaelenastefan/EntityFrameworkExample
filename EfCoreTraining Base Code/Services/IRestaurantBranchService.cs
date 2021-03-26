
using System.Collections.Generic;

using Models;

namespace Services
{
    public interface IRestaurantBranchService
    {
        public List<RestaurantBranchViewModel> GetAll();
    }
}
