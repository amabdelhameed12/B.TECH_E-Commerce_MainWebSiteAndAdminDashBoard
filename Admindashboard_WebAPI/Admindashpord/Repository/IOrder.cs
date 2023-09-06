using Admindashpord.Models;

namespace Admindashpord.Models
{
    public interface IOrder
    {
        public List<Order> GetAllOrder();
        //public List<Order> GetAllByDate(DateTime OrderDate);
        public Order GetById(int OrderNumber);
        public void Insert(Order item);

        public void Update(int OrderNumber, Order order);
        public void DeleteById(int OrderNumber);
    }
}
