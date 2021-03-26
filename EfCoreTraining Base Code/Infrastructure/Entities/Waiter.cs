
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class Waiter
    {
        public int WaiterId { get; set; }

        public string Name { get; set; }

        public string Age { get; set; }

        public virtual OrderTable OrderTable { get; set; }
        public virtual ICollection<WaiterOrderTable> WaiterOrderTables { get; set; }
    }
}