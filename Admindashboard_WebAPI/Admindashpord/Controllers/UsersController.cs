using Admindashpord.Models;
using Admindashpord.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Admindashpord.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class UsersController : Controller
  {
    Iusers userrepo;
    private readonly IConfiguration _cofiguration;
    public UsersController(Iusers _userrepo, IConfiguration configuration)
    {
      userrepo = _userrepo;
      _cofiguration = configuration;

    }

    [HttpGet]
    [Route("GetAllUsers")]
    //[Authorize]
    public IActionResult GetAllCustomers()
    {
      List<Customer> customers = userrepo.GetAll();

      return Ok(customers);
    }
  }
}
