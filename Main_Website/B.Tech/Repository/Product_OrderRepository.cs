using B.Tech.Models;

namespace B.Tech.Repository
{
    public class Product_OrderRepository : IProduct_Order
    {
        
        Context context;
        public Product_OrderRepository()
        {
            context = new Context();
        }
        public void Insert(Product_Order item)
        {
            context.product_Orders.Add(item);
            context.SaveChanges();
        }
    }
}
