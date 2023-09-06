using B.Tech.Models;
using B.Tech.Repository;
using B.Tech.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using System.Security.Principal;

namespace B.Tech.Controllers
{
    [Authorize]


    public class CustomerController : Controller
    {
        private readonly ILogin _customerRepository;
        private readonly IOrder _orderRepository;
        private readonly ICategory _categeoryRepository;

        Context Context;
        public CustomerController(ILogin customerRepository , IOrder orderRepo , ICategory categoryRepo)
        {
            _customerRepository = customerRepository;
            
            _orderRepository = orderRepo;
            _categeoryRepository = categoryRepo;
            Context = new Context();
        }


        public ActionResult Login()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (_customerRepository.Found(username, password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid username or password";
                return View();
            }
        }

   
        public ActionResult ResetPassword()
        {
            return View();
        }

  
        [HttpPost]
        public ActionResult ResetPassword(string OldPassword, string Newpassword)
        {
            if (_customerRepository.Reset(OldPassword, Newpassword))
            {
                ViewBag.Success = "Password has been reset successfully";
                return View();
            }
            else
            {
                ViewBag.Error = "Invalid password";
                return View();
            }
        }

        [Authorize]

        public ActionResult Index()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var userIdClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            var userId = userIdClaim != null ? userIdClaim.Value : null;

            var customer=  _customerRepository.GetById(int.Parse(userId));

           List<Order> custom_ord = _orderRepository.GetAllByCostomer(int.Parse(userId));
            var C_order = new CustomerWithOrders();
            C_order.orders=custom_ord;
            C_order.Customer=customer;
            return View(customer);
        }


        [Authorize]
        public ActionResult OrdDEtails(int id)
        {
            List<Order> custom_ords = _orderRepository.GetAllByCostomer(id);
         

            return View(custom_ords);
        }


        [Authorize]

        public IActionResult ProductsForOrder(int orderNumber)
        {
            var productsForOrder = _orderRepository.GetOrdersWithPrds(orderNumber);

            return View(productsForOrder);
        }
   

        [Authorize]
        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerEditViewModel
            {
            
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
                Password = customer.Password
            };

            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, CustomerEditViewModel viewModel)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                customer.FirstName = viewModel.FirstName;
                customer.LastName = viewModel.LastName;
                customer.Address = viewModel.Address;
                customer.PhoneNumber = viewModel.PhoneNumber;
                customer.Password = viewModel.Password;
                _customerRepository.Update(id ,customer);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }




    }
}
