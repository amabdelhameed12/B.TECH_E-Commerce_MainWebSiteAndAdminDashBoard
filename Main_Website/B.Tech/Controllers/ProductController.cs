using B.Tech.Models;
using B.Tech.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B.Tech.Controllers
{
  
    public class ProductController : Controller
    {
        IProduct iproductRepo;

      public ProductController(IProduct _productrepo) 
        {
        iproductRepo = _productrepo;
        
        }
     
        public IActionResult Index(int id)
        {
           
            return View(iproductRepo.GetById(id));
        }
        [HttpGet]
        public ActionResult Search(string searchProduct)
        {
            List<Product> products = iproductRepo.GetAll().Where(p => p.Name.Contains(searchProduct)).ToList();
            return View(products);
        }
    }
}
