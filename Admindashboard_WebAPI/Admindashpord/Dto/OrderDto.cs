using Admindashpord.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admindashpord.Dto
{
    public class OrderDto
    {
        public int OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? Total { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { set; get; }
        public string status { get; set; }


    [ForeignKey("PaymentMethod")]
        public int? PaymentMethodId { set; get; }
        
    }
}
