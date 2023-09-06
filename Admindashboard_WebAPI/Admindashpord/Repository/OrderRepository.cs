using Admindashpord.Models;

namespace Admindashpord.Repository
{
    public class OrderRepository : IOrder
    {
        Context context;
        public OrderRepository()
        {
            context = new Context();
        }
        public void DeleteById(int OrderNumber)
        {
            Order order = GetById(OrderNumber);
            context.Orders.Remove(order);
        }

        public List<Order> GetAllOrder()
        {
            return context.Orders.ToList();
        }
        public List<Order> GetAllByDate(DateTime OrderDate)
        {
            return context.Orders.Where(o => o.OrderDate == OrderDate).ToList();
        }
        public Order GetById(int OrderNumber)
        {
            return context.Orders.FirstOrDefault(o => o.OrderNumber == OrderNumber);
        }

        public void Insert(Order item)
        {
            context.Orders.Add(item);
        }

        public void Update(int OrderNumber, Order order)
        {
            Order ordermodel = context.Orders.FirstOrDefault(c => c.OrderNumber == OrderNumber);
      
            ordermodel.OrderNumber = order.OrderNumber;
            ordermodel.OrderDate = order.OrderDate;
            ordermodel.Total = order.Total;
            ordermodel.CustomerId = order.CustomerId;
            ordermodel.Status = order.Status;
            context.SaveChanges();
            
        }

    }
}
