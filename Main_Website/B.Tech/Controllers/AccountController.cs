using B.Tech.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Security.Claims;
using B.Tech.Models;
using B.Tech.ViewModel;
using Microsoft.AspNetCore.Authorization;


namespace B.Tech.Controllers
{
  
    public class AccountController : Controller
    {
        ILogin login;
        public AccountController(ILogin _login) 
        { 
            login = _login;

        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email ,string password )
        {
            var a=login.Found(Email , password);
            if (a)
            {
                Customer customermodel = login.find(Email, password);
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim("Id", customermodel.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, customermodel.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, customermodel.FirstName.ToString()+" "+ customermodel.LastName.ToString()));
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("Index", "Home");

            }

            return View();

        }
        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult NewUser()
        {
            var viewModel = new CustomerCreateViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult NewUser(CustomerCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer
                {
                    Email = viewModel.Email,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,
                    Address = viewModel.Address,
                    PhoneNumber = viewModel.PhoneNumber,
                    Password = viewModel.Password
                };
                login.Insert(customer);
                return RedirectToAction("Login");
            }

            return View(viewModel);
        }

    }
    
}
