using Admindashpord.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admindashpord.Dto
{
    public class ProductDto
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { set; get; }
    }
}
