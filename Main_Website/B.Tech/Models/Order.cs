using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace B.Tech.Models
{
    public class Order
    {

        [Key]
        public int OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }

        public decimal? Total { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { set; get; }
        public Customer? Customer { get; set; }
        public List<Product_Order>? Product_Order { get; set; }
        public string? Status { get; set; }

    }
}
