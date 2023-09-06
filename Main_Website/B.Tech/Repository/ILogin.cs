using B.Tech.Models;
using Microsoft.Identity.Client;

namespace B.Tech.Repository
{
    public interface ILogin
    {
        public void Insert(Customer item);
        public bool Found (string Email, string password);
        Customer find(string Email, string password);
        public bool Reset(string OldPassword, string Newpassword);
        public Customer GetById(int customerid);
        public void Update(int id, Customer _customer);
        List<Order> GetOrdersWithPrds(int id);
    }
}
