using Admindashpord.Models;
using Admindashpord.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admindashpord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ILogin loginrepo;
        public LoginController(ILogin _loginrepo)
        {
            loginrepo= _loginrepo;
        }
        [HttpPost]
        [Route("Found")]
        public IActionResult Found([FromBody] LoginRequest request)
        {
          bool found = loginrepo.Found(request.Name, request.Password);

          return Ok(found);
        }
        [HttpPost]
        [Route("RestPassword")]
        //[Authorize]
        public IActionResult RestPassword(string OldPassword, string Newpassword)
        {
            loginrepo.Reset(OldPassword,Newpassword);

            return Ok();
        }
    }
}
