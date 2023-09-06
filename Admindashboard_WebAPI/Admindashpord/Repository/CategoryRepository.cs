using Admindashpord.Models;
using Admindashpord.Dto;


namespace Admindashpord.Repository
{
    public class CategoryRepository : ICategory
    {
        Context context;
        public CategoryRepository() {
            context=new Context();
        }
        public void DeleteById(int id)
        {
            Category category= GetById(id);
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(c=>c.ID==id);
        }

        public void Insert(Category category)
        {
            context.Categories.Add(category); 
            context.SaveChanges();
        }

        public void Update(int id, Category category)
        {
            Category categoryModel=context.Categories.FirstOrDefault(c=>c.ID==id);
            categoryModel.Name=category.Name;
            context.SaveChanges();
        }
        public List<Product> GetByCatID(int CatID)
        {
            return context.Products.Where(e => e.CategoryId == CatID).ToList();
        }

    }
}
