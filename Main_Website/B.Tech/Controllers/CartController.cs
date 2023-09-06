using B.Tech.Models;
using B.Tech.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;

namespace B.Tech.Controllers
{
    //[Authorize]
    public class CartController : Controller
    {
        private IProduct _product;

        public CartController(IProduct productRepo)
        {
            _product = productRepo;
        }

        public IActionResult Index()
        {
            var value = HttpContext.Session.GetString("CartDetails");
            var cart = value == null ? new CartItemViewModel() : JsonConvert.DeserializeObject<CartItemViewModel>(value);
            HttpContext.Session.SetString("CartDetails", JsonConvert.SerializeObject(cart));
            HttpContext.Session.SetString("OrderDetails", JsonConvert.SerializeObject(cart));
            return View(cart.Products);
        }

        [HttpPost]
        public IActionResult AddToCart([FromBody] CartItemViewModel cartitemviewmodel)
        {
            var cart = new CartItemViewModel();
            foreach (var productId in cartitemviewmodel.productIds)
            {
                var product = _product.GetById(productId);
                if (product != null)
                {
                    var existingProduct = cart.Products.Find(p => p.ID == product.ID);
                    if (existingProduct != null)
                    {
                        cart.Products.Remove(existingProduct);
                        existingProduct.Quantity++;
                        cart.Products.Add(existingProduct);
                    }
                    else
                    {
                        product.Quantity = 1;
                        cart.Products.Add(product);
                    }
                }
            }

            HttpContext.Session.SetString("CartDetails", JsonConvert.SerializeObject(cart));

            return Ok();
        }

        [HttpPost]
        public IActionResult CheckOut()
        {
            bool isLoggedIn = User.Identity.IsAuthenticated;
            if (isLoggedIn)
            {
                return RedirectToAction("Create", "Order");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public IActionResult RemoveFromCart(int ProductId)
        {
            var value = HttpContext.Session.GetString("CartDetails");
            var Prds = value == null ? new CartItemViewModel() : JsonConvert.DeserializeObject<CartItemViewModel>(value);
            var productToRemove = Prds.Products.Find(p => p.ID == ProductId);
            if (productToRemove != null)
            {
                if (productToRemove.Quantity > 1)
                {
                    productToRemove.Quantity--;
                }
                else
                {
                    Prds.Products.Remove(productToRemove);
                }
                HttpContext.Session.SetString("CartDetails", JsonConvert.SerializeObject(Prds));
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult IncreaseQuantity(int ProductId)
        {
            var value = HttpContext.Session.GetString("CartDetails");
            var cart = value == null ? new CartItemViewModel() : JsonConvert.DeserializeObject<CartItemViewModel>(value);
            var product = cart.Products.FirstOrDefault(p => p.ID == ProductId);
            if (product != null)
            {
                product.Quantity++;
                HttpContext.Session.SetString("CartDetails", JsonConvert.SerializeObject(cart));
            }
            return RedirectToAction("Index");
        }
    

    }
}