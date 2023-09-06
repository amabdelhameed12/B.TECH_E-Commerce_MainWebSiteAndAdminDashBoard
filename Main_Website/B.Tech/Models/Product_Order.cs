using B.Tech.Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace B.Tech.Models
{
    public class Product_Order
    {
        [Key]
        public int Id { get; set; }

   
        [ForeignKey("Product")]

        public int PrdId { get; set; }
      
        [ForeignKey("Order")]
     
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int? Product_Quantity { get; set; }


    }
}
