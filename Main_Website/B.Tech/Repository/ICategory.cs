using B.Tech.Models;

namespace B.Tech.Repository
{
    public interface ICategory
    {
        public List<Category> GetAll();
        public Category GetById(int id);
        public void Insert(Category item);
        public List<Product> GetByCatID(int CatID);
        public void Update(int id, Category category);
        public void DeleteById(int id);
    }
}