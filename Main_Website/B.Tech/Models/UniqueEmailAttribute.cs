using System.ComponentModel.DataAnnotations;

namespace B.Tech.Models
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string Email = value.ToString();
            Context context = new Context();
            Customer customer = context.Customers.FirstOrDefault(e => e.Email == Email);
            if (customer == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Email Already Found");
            }
        }
    }
}
