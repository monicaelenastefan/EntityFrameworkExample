using Infrastructure;
using AutoMapper;
using System.Linq;
using Models;
using Infrastructure.Entities;

namespace Services
{
    public class OrderTableService : IOrderTableService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
    

        public OrderTableService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public OrderTableViewModel GetById(int id)
        {
            var x = _mapper.Map<OrderTableViewModel>(_context.OrderTable.FirstOrDefault(p => p.Id == id));
            return x;
        }

        public DatabaseContext GetContext()
        {
            return _context;
        }


        public bool Delete(int id)
        {
            var item = _context.OrderTable.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return false;
            }

            _context.OrderTable.Remove(item);
            _context.SaveChanges();

            return true;
        }

       
    }
}
