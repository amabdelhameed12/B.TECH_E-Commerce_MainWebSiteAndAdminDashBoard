using B.Tech.Models;

namespace B.Tech.Repository
{
    public interface IOrder
    {
        public List<Order> GetAllByCostomer(int customerid);
        //public List<Order> GetAllByDate(DateTime OrderDate);
        public Order GetById(int OrderNumber);
      
        public void Insert(Order item);
        public List<Product_Order> GetOrdersWithPrds(int orderId);
        //public void Update(int OrderNumber, Order order);
        //public void DeleteById(int OrderNumber);
    }
}
