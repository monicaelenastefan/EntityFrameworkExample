
using AutoMapper;
using Infrastructure.Entities;
using Models;

namespace Services
{
    public class OrderTableProfile:Profile
    {
        public OrderTableProfile()
        {
            CreateMap<OrderTable, OrderTableViewModel>();
        }
    }
}
