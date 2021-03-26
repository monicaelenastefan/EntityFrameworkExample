
using System.Collections.Generic;
using Infrastructure;
using Infrastructure.Entities;
using Models;

namespace Services
{
    public interface IOrderTableService
    {
        public OrderTableViewModel GetById(int id);

        public DatabaseContext GetContext();

        public bool Delete(int id);

      
    }
}
