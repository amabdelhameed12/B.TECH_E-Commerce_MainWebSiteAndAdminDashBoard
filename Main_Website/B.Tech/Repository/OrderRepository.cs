using B.Tech.Models;
using Microsoft.EntityFrameworkCore;

namespace B.Tech.Repository
{
    public class OrderRepository : IOrder
    {
        Context context;
        public OrderRepository()
        {
            context = new Context();
        }
        //public void DeleteById(int OrderNumber)
        //{
        //    Order order=GetById(OrderNumber);
        //    context.Orders.Remove(order);
        //}

        public List<Order> GetAllByCostomer(int customerid)
        {
            return context.Orders.Where(o => o.CustomerId == customerid).ToList();
        }
        //public List<Order> GetAllByDate(DateTime OrderDate)
        //{
        //    return context.Orders.Where(o => o.OrderDate == OrderDate).ToList();
        //}
        public Order GetById(int OrderNumber)
        {
            return context.Orders.FirstOrDefault(o => o.OrderNumber == OrderNumber);
        }

        public void Insert(Order item)
        {
            context.Orders.Add(item);
            context.SaveChanges();
        }

        //public void Update(int OrderNumber, Order order)
        //{
        //    Order orderModel = GetById(OrderNumber);
        //    orderModel.OrderDate = DateTime.Today;
        //}



        public List<Product_Order> GetOrdersWithPrds(int orderId)
        {


            return context.product_Orders.Where(po => po.Order.OrderNumber == orderId)
                                           .Include(po => po.Product)
                                           .ToList(); 
        }

       









        //public List<Order> GetOrdersWithPrds(int orderId)
        //{
        //    var ordersWithProductOrders = context.Orders
        //                                          .Where(o => o.CustomerId == orderId)
        //                                          .Include(o => o.Product_Order)
        //                                          .ToList();

        //    return ordersWithProductOrders;
        //}
    }
}
