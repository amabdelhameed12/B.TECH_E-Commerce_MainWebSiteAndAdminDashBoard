namespace Admindashpord.Models
{
    public class cartitemviewmodel
    {

        public List< Product>? Products { get; set; }
        public List< int>? productIds { get; set; }
        //public int Quantity { get; set; }

        public cartitemviewmodel()
        {
            productIds = new List< int >();
            Products = new List< Product >();
           
        }

    }
}
//var exist = cart.Products.Where(p => p.ID == productId).FirstOrDefault();
//if (exist != null)
//{
//    exist.Quantity++;
//}


//exist.Quantity = 1;
//cart.Products.Add(exist);
