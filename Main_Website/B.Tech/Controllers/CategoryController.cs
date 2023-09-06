using B.Tech.Models;
using B.Tech.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace B.Tech.Controllers
{
 
    public class CategoryController : Controller
    {
        ICategory categoryRepository;
        IProduct productRepository;
      
        Context context;

        public CategoryController(ICategory _categoryRepository, IProduct _productRepository )
        {
            categoryRepository= _categoryRepository;
            productRepository= _productRepository;
           
            this.context = context;
        }

     


        public IActionResult everydayDeals()
        {

            var categories = categoryRepository.GetAll();

            var topProductsByCategory = new List<List<Product>>();

            foreach (var category in categories)
            {

                topProductsByCategory.Add(category.Products.Where(p => p.Discount == 0.2m).ToList());

            }

            return View(topProductsByCategory);
        }
        public IActionResult GetProdByCatId(int id)
        {
            
            return View(categoryRepository.GetByCatID(id));

        }
        public IActionResult New()
        {
            ViewData["Prods"] = productRepository.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult New(Category newCat)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    categoryRepository.Insert(newCat);
                    return RedirectToAction("GetAll");
                }
                catch (Exception ex)
                {
                    
                    ModelState.AddModelError("Exception", ex.InnerException.Message);
                }
            }
            ViewData["Prods"] = productRepository.GetAll();
            return View(newCat);
        }
        public void Delete(int id) {
            categoryRepository.DeleteById(id);
        }
        public IActionResult Edit(int id)
        {
            Category CatModel = categoryRepository.GetById(id);
            ViewData["Prods"] = productRepository.GetAll();
            return View(CatModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, Category CatForm)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Update(id, CatForm);
                return RedirectToAction("GetAll");
            }
            ViewData["Prods"] = productRepository.GetAll();
            return View(CatForm);
        }

    }
}
