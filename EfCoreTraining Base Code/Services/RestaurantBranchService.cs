using Infrastructure;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Services
{
    public class RestaurantBranchService:IRestaurantBranchService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public RestaurantBranchService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }




        public List<RestaurantBranchViewModel> GetAll()
        {

            List<RestaurantBranchViewModel> result = new List<RestaurantBranchViewModel>();
            var restaurantBranches = _mapper.Map<List<RestaurantBranchViewModel>>(_context.RestaurantBranch.ToList());

            return restaurantBranches;
        }
    }
}