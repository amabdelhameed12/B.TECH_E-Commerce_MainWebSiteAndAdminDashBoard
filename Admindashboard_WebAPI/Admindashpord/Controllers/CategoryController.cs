using Admindashpord.Models;
using Admindashpord.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Admindashpord.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        ICategory categoryRepository;
        private readonly IConfiguration _cofiguration;

        public CategoryController(ICategory _categoryRepository, IConfiguration configuration)
        {
            categoryRepository = _categoryRepository;
            _cofiguration = configuration;

        }
        [HttpPost]
        [Route("AddCategory")]
        //[Authorize]
        public IActionResult AddCategory(Category category)
        {
            categoryRepository.Insert(category);

            return Ok(category);
        }
        [HttpGet]
        [Route("GetAllCategory")]
        //[Authorize]
        public IActionResult GetAllCategory()
        {
            List<Category> category = categoryRepository.GetAll();

            return Ok(category);
        }
        [HttpGet]
        [Route("GetCategorybyid")]
        //[Authorize]
        public IActionResult GetCategory(int id)
        {
            var category = categoryRepository.GetById(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [HttpPut]
        [Route("updatecategory")]
        //[Authorize]
        public IActionResult updateCategory(int id, Category category)
        {
            categoryRepository.Update(id, category);


            return Ok(category);
        }
        [HttpDelete]
        [Route("DeleteCategory")]
        //[Authorize]
        public IActionResult DeleteCategory(int id)
        {
            categoryRepository.DeleteById(id);

            return Ok();
        }
        [HttpGet("Token")]
        public IActionResult GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_cofiguration.GetSection("SecretKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Name, "test"),
                        new Claim(ClaimTypes.Role, "Admin"),
                    }),
                Expires = DateTime.UtcNow.AddDays(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            return Ok(tokenHandler.WriteToken(token));
        }
    }
}
