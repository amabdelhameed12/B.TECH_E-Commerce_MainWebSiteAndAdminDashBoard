using B.Tech.Models;
using B.Tech.Repository;
using System.Drawing.Printing;

namespace B.Tech.ViewModel
{
    public class CustomerWithOrders
    {
        public List<Order>? orders { get; set; }
        public Customer? Customer { get; set; }
        public CustomerWithOrders()
        {
            orders = new List<Order>();
            Customer = new Customer();

        }
    }
}
