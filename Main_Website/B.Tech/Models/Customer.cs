using System.ComponentModel.DataAnnotations;

namespace B.Tech.Models
{
    
    public class Customer
    {

        public int Id { set; get; }
        [MinLength(3, ErrorMessage = "first name must be more than 2 char")]
        [MaxLength(25, ErrorMessage = "first name must be less than 25 char")]
        public string FirstName { get; set; }
        [MinLength(3, ErrorMessage = " last name must be more than 2 char")]
        [MaxLength(25, ErrorMessage = "last name must be less than 25 char")]
        public string LastName { get; set; }

        //[Required(AllowEmptyStrings = true)]
        //[RegularExpression("^[a-zA-Z]+@[a-zA-Z]+\\.(com)$", ErrorMessage = "Email must contain @ and end with .com")]
        //[UniqueEmail]
        public string Email { get; set; }
        public string Address { get; set; }
        [RegularExpression("^0[0-9]{10}$", ErrorMessage = "Please enter a valid phone number that contains 11 digits")]

        public string PhoneNumber { get; set; }
        public List<Order>? Orders { get; set; }
        [MinLength(8, ErrorMessage = " Password must be more than 8 number ")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        


    }
}
