using Admindashpord.Models;

namespace Admindashpord.Repository
{
    public class ProductRepository : IProduct
    {
        Context context;
        public ProductRepository()
        {
            context = new Context();
        }
        public void DeleteById(int id)
        {
            Product product = GetById(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product GetById(int id)
        {
            return context.Products.FirstOrDefault(p => p.ID == id);
        }

        public List<Product> GetCrs(int CatID)
        {
            return context.Products.Where(p=>p.CategoryId==CatID).ToList();
        }

        public void Insert(Product item)
        {
            context.Products.Add(item);
            context.SaveChanges();
        }

        public void Update(int id, Product product)
        {
            Product productModel= GetById(id);
            productModel.Name = product.Name;
            productModel.Description = product.Description;
            productModel.Price = product.Price;
            productModel.Quantity = product.Quantity;
            productModel.ImageUrl = product.ImageUrl;
            productModel.Discount = product.Discount;
            productModel.CategoryId = product.CategoryId;
            context.SaveChanges();
        }
    }
}
