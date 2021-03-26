using AutoMapper;
using Infrastructure.Entities;
using Models;

namespace Services
{
    public class RestaurantBranchProfile : Profile
    {
        public RestaurantBranchProfile()
        {
            CreateMap<RestaurantBranch, RestaurantBranchViewModel>();
        }
    }
}
