using B.Tech.Models;
using B.Tech.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Principal;

namespace B.Tech.Controllers
{
    
    public class OrderController : Controller
    {
       
            private readonly IOrder _orderRepository;
            private readonly IProduct_Order _product_OrderRepository;
            private readonly IProduct _productRepository;
        public OrderController(IOrder orderRepository , IProduct_Order product_OrderRepository ,IProduct productRepository)
            {
                _orderRepository = orderRepository;
                _product_OrderRepository= product_OrderRepository;
                _productRepository = productRepository;
            }

     
        [Authorize]
        public IActionResult Create()
            {
            var value = HttpContext.Session.GetString("OrderDetails");
            var x = value == null ? new CartItemViewModel() : JsonConvert.DeserializeObject<CartItemViewModel>(value);
            ViewBag.q = User.Identity.Name;
    
            ViewBag.total=x.Products.Sum(p=>((1-p.Discount)*p.Price*p.Quantity));
            return View(x.Products);
            }
        [Authorize]
        public IActionResult Confirm()
            {
            var value = HttpContext.Session.GetString("CartDetails");
            var x = value == null ? new CartItemViewModel() : JsonConvert.DeserializeObject<CartItemViewModel>(value);
            var identity = (ClaimsIdentity)User.Identity; 
            var userIdClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? userIdClaim.Value : null;
            var order = new Order();
            order.OrderDate = DateTime.Now;
            order.Total = (decimal)x.Products.Sum(p => ((1 - p.Discount) * p.Price * p.Quantity));
            order.CustomerId = string.IsNullOrEmpty(userId) ? 0 : int.Parse(userId);
            order.Status = " Processed";
            _orderRepository.Insert(order);
            var prd_ord=new Product_Order();
            foreach (var prd in x.Products)
            {
             Product product=  _productRepository.GetById(prd.ID);
                product.Quantity-=prd.Quantity;
                _productRepository.Update(product.ID, product);
                prd_ord.PrdId = prd.ID;
                prd_ord.OrderId = order.OrderNumber;
                prd_ord.Product_Quantity = prd.Quantity;
                _product_OrderRepository.Insert(prd_ord);
            }

            if (order == null)
            {
                return NotFound();
            }



            HttpContext.Session.SetString("orderstatus", JsonConvert.SerializeObject(order));


            return RedirectToAction("Orderstate");


            }
        [Authorize]
        public IActionResult Orderstate()
        {
         
            var x  = HttpContext.Session.GetString("CartDetails");
            var cart = x == null ? new CartItemViewModel() : JsonConvert.DeserializeObject<CartItemViewModel>(x);
        

            var value = HttpContext.Session.GetString("orderstatus");
            var order = value == null ? new Order() : JsonConvert.DeserializeObject<Order>(value);

            return View(order);

        }































            // /////////////////////////////////////////////////
            //public ActionResult Details(int id)
            //{
            //    Order order = _orderRepository.GetById(id);
            //    return View(order);
            //}

            //public ActionResult Create()
            //{
            //    return View();
            //}


            //[HttpPost]
            //public ActionResult Create(Order order)
            //{
            //    try
            //    {
            //        _orderRepository.Insert(order);
            //        return RedirectToAction("Index", "Home");
            //    }
            //    catch
            //    {
            //        return View();
            //    }
            //}
        }
    }

