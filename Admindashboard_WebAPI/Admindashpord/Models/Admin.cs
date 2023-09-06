using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Admindashpord.Models
{
    public class Admin
    {
        public int? Id { set; get; }
        [DisplayName ( "UserName")]
        public string name { set; get; }
        public string password { set; get; }
    }
}
