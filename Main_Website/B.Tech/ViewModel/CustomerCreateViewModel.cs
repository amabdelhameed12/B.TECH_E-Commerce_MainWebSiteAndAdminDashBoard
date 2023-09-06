using B.Tech.Models;
using System.ComponentModel.DataAnnotations;

namespace B.Tech.ViewModel
{
    public class CustomerCreateViewModel
    {
        [Required(ErrorMessage = "Please enter a valid email address")]
        [RegularExpression("^[a-zA-Z]+@[a-zA-Z]+\\.(com)$", ErrorMessage = "Email must be contain @ and end with .com ")]
        [UniqueEmail]
        public string Email { get; set; }

        [MinLength(3, ErrorMessage = "first name must be more than 2 char")]
        [MaxLength(25, ErrorMessage = "first name must be less than 25 char")]
        public string FirstName { get; set; }

        [MinLength(3, ErrorMessage = " last name must be more than 2 char")]
        [MaxLength(25, ErrorMessage = "last name must be less than 25 char")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [RegularExpression("^0[0-9]{10}$", ErrorMessage = "Please enter a valid phone number that contains 11 digits")]
        public string PhoneNumber { get; set; }

        [MinLength(8, ErrorMessage = " Password must be more than 8 number ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
