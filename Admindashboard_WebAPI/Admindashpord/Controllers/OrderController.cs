using Admindashpord.Models;
using Admindashpord.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admindashpord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrder orederrepo;
        public OrderController(IOrder _orederrepo)
        {
            orederrepo = _orederrepo;
        }
        [HttpGet]
        [Route("GetAllOrder")]
        //[Authorize]
        public IActionResult GetAllOrder()
        {
            List<Order> orders = orederrepo.GetAllOrder();

            return Ok(orders);
        }
        [HttpGet]
        [Route("GetOrderbyid")]
        //[Authorize]
        public IActionResult GetOrderbyid(int ordernumber)
        {
            var order = orederrepo.GetById(ordernumber);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }
        [HttpPut]
        [Route("updateOrder")]
        //[Authorize]
        public IActionResult updateOrder(int ordernumber, Order order)
        {
            orederrepo.Update(ordernumber, order);

            return Ok(order);
        }
        [HttpDelete]
        [Route("DeleteOrder")]
        //[Authorize]
        public IActionResult DeleteOrder(int ordernumber)
        {
            orederrepo.DeleteById(ordernumber);

            return Ok();
        }

    }
  }
