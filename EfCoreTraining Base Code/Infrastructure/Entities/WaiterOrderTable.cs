
namespace Infrastructure.Entities
{
    public class WaiterOrderTable
    {
        public int WaiterId { get; set; }
        public int OrderTableId { get; set; }

        public virtual Waiter Waiter { get; set; }
        public virtual OrderTable OrderTable { get; set; }
    }
}