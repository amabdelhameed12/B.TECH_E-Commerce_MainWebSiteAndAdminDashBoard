using Admindashpord.Models;

namespace Admindashpord.Repository
{
    public interface ILogin
    {

        public void Insert(Admin item);
        public bool Found (string name, string password);
        //Admin find(string name, string password);
        public bool Reset(string OldPassword, string Newpassword);
    }
}
