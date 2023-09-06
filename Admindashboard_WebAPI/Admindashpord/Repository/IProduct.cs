using Admindashpord.Models;

namespace Admindashpord.Repository
{
    public interface IProduct
    {
        public List<Product> GetAll();
        public Product GetById(int id);
        public void Insert(Product item);
        public void Update(int id, Product category);
        public void DeleteById(int id);
        public List<Product> GetCrs(int CatID);
    }
}
