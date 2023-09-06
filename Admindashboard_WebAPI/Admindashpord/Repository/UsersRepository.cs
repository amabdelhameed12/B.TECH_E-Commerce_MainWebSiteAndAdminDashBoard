using Admindashpord.Models;

namespace Admindashpord.Repository
{
  public class UsersRepository :Iusers
  {
    Context context;
    public UsersRepository(Context context)
    {
      this.context = context;
    }
    public List<Customer> GetAll()
    {
      return context.Customers.ToList();
    }
  }
}
