using B.Tech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace B.Tech.Repository
{
    public class CostomerRepository:ILogin
    {
        Context context;
        public CostomerRepository(Context context)
        {
            this.context = context;
        }
        public void Insert(Customer item)
        {
            context.Customers.Add(item);
            context.SaveChanges();
        }

        public bool Found(string Email, string password)
        {
            var found = context.Customers.FirstOrDefault(a => a.Email == Email && a.Password == password);
            if (found != null)
            {
               
                return true;
            }
            return false;
        }

        public bool Reset(string OldPassword, string Newpassword)
        {
            Customer customer = context.Customers.FirstOrDefault(a => a.Password == OldPassword);
            if (customer != null)
            {
                customer.Password = Newpassword;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
      
        Customer ILogin.find(string Email, string password)
        {
            Customer acount = context.Customers.FirstOrDefault(a => a.Email == Email && a.Password == password);
            return acount;
        }

        public Customer GetById(int customerid)

        {
            Customer Customer = context.Customers.FirstOrDefault(a => a.Id == customerid);
            return Customer;
        }
        public void Update(int id , Customer  _customer)
        {
            Customer Customer = context.Customers.FirstOrDefault(a => a.Id == id);
            Customer.FirstName = _customer.FirstName; Customer.LastName=_customer.LastName;
            Customer.Address=_customer.Address; Customer.PhoneNumber = _customer.PhoneNumber;
            Customer.Email= _customer.Email;Customer.Password = _customer.Password;
            //context.Customers.Update(Customer);
            context.SaveChanges();

        }


        //public List<Order> GetOrdersWithPrds(int id)
        //{
        //    return context.Orders.Include(c => c.Product_Order).ToList(); ;
        //}

        public List<Order> GetOrdersWithPrds(int orderId)
        {
            var ordersWithProductOrders = context.Orders
                                                  .Where(o => o.CustomerId == orderId)
                                                  .Include(o => o.Product_Order)
                                                  .ToList();

            return ordersWithProductOrders;
        }

        //public List<Product_Order> GetOrdersWithPrds(int orderId)
        //{
        //    var ordersWithProductOrders = context.product_Orders
        //                                          .Where(o => o.OrderId == orderId)
        //                                          .ToList();

        //    return ordersWithProductOrders;
        //}


    }
}
