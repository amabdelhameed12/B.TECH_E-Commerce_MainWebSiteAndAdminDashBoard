namespace B.Tech.Models
{
    public class CartItemViewModel
    {

        public List< Product>? Products { get; set; }
        public List< int>? productIds { get; set; }


        public CartItemViewModel()
        {
            productIds = new List< int >();
            Products = new List< Product >();
           
        }

    }
}

