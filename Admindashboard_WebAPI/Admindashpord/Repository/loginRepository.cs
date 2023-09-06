using Microsoft.Identity.Client;
using Admindashpord.Models;

namespace Admindashpord.Repository
{
    public class loginRepository:ILogin
    {
        Context context;
        public loginRepository(Context context)
        {
            this.context = context;
        }

    public void Insert(Admin item)
        {
            context.Admins.Add(item);
            context.SaveChanges();
        }

        public bool Found(string name, string password)
        {
            var found = context.Admins.FirstOrDefault(a => a.name == name && a.password == password);
            if (found != null)
            {
                return true;
            }
            return false;
        }

        public bool Reset(string OldPassword, string Newpassword)
        {
            Admin admin = context.Admins.FirstOrDefault(a => a.password == OldPassword);
            if (admin != null)
            {
                admin.password = Newpassword;
                context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //Customer ILogin.find(string name, string password)
        //{
        //    Admin acount = context.Admins.FirstOrDefault(a => a.Name ==name && a.Password == password);
        //    return acount;
        //}
    }
}
