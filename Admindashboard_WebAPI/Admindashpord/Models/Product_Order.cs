
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Admindashpord.Models
{
    public class Product_Order
    {
        [Key]
        public int Id { get; set; }

        //[Key]
        [ForeignKey("Product")]
        //[Column(Order = 1)]
        public int PrdId { get; set; }
        //[Key]
        [ForeignKey("Order")]
        //[Column(Order = 2)]
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int? Product_Quantity { get; set; }


    }
}
