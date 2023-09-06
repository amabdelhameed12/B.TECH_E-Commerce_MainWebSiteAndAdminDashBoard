//using Admindashpord.Dto;
//using Admindashpord.Models;
//using Admindashpord.Repository;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace Admindashpord.Controllers
//{

//  [Route("api/[Controller]")]
//  [ApiController]
//  public class ProductController : Controller
//  {
//    IProduct iproductRepo;

//    public ProductController(IProduct _productrepo)
//    {
//      iproductRepo = _productrepo;

//    }
//    [HttpPost]
//    [Route("Addproduct")]
//    //[Authorize]
//    public IActionResult Addproduct(Product product)
//    {
//      iproductRepo.Insert(product);

//      return Ok(product);
//    }
//    [HttpGet]
//    [Route("GetAllProduct")]
//    //[Authorize]
//    public IActionResult GetAllProduct()
//    {
//      List<Product> products = iproductRepo.GetAll();

//      return Ok(products);
//    }
//    [HttpGet]
//    [Route("GetProductbyid")]
//    //[Authorize]
//    public IActionResult GetProductbyid(int id)
//    {
//      var product = iproductRepo.GetById(id);
//      if (product == null)
//      {
//        return NotFound();
//      }

//      return Ok(product);
//    }
//    [HttpPut]
//    [Route("updateproduc")]
//    //[Authorize]
//    public IActionResult updateproduct(int id, Product product)
//    {
//      iproductRepo.Update(id, product);

//      return Ok(product);
//    }
//    [HttpDelete]
//    [Route("DeleteProduct")]
//    //[Authorize]
//    public IActionResult DeleteProduct(int id)
//    {
//      iproductRepo.DeleteById(id);

//      return Ok();
//    }
//  }
//}



using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using Admindashpord.Models;
using Admindashpord.Repository;
using System.Collections.Generic;

namespace Admindashpord.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class ProductController : Controller
  {
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly IProduct _iproductRepo;

    public ProductController(IWebHostEnvironment hostingEnvironment, IProduct productRepo)
    {
      _hostingEnvironment = hostingEnvironment;
      _iproductRepo = productRepo;
    }

    [HttpPost("AddProduct")]
    //[Authorize]
    public IActionResult AddProduct([FromBody] Product product)
    {
      _iproductRepo.Insert(product);

      return Ok(product);
    }

    [HttpGet("GetAllProduct")]
    //[Authorize]
    public IActionResult GetAllProduct()
    {
      List<Product> products = _iproductRepo.GetAll();

      return Ok(products);
    }

    [HttpGet("GetProductById")]
    //[Authorize]
    public IActionResult GetProductById(int id)
    {
      var product = _iproductRepo.GetById(id);
      if (product == null)
      {
        return NotFound();
      }

      return Ok(product);
    }

    [HttpPut("UpdateProduct")]
    //[Authorize]
    public IActionResult UpdateProduct(int id, [FromBody] Product product)
    {
      _iproductRepo.Update(id, product);

      return Ok(product);
    }

    [HttpDelete("DeleteProduct")]
    //[Authorize]
    public IActionResult DeleteProduct(int id)
    {
      _iproductRepo.DeleteById(id);

      return Ok();
    }

    [HttpPost("UploadFile")]
    //[Authorize]
    public IActionResult UploadFile(IFormFile file)
    {
      if (file != null && file.Length > 0)
      {
        try
        {
          var filename = Path.GetFileName(file.FileName);
          //var path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", filename);
          var path = Path.Combine("wwwroot", "uploads", filename);

          using (var stream = new FileStream(path, FileMode.Create))
          {
            file.CopyTo(stream);
          }

          return Ok(new { message = "File uploaded successfully" });
        }
        catch (Exception ex)
        {
          return StatusCode(500, $"Internal server error: {ex}");
        }
      }
      else
      {
        return BadRequest("No file selected");
      }
    }
    [HttpGet("{imageName}")]
    public IActionResult GetImage(string imageName)
    {
      var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", imageName);

      if (!System.IO.File.Exists(imagePath))
      {
        return NotFound(); // Return 404 if image not found
      }

      var imageFileStream = System.IO.File.OpenRead(imagePath);
      return File(imageFileStream, "image/jpeg"); // Adjust the content type as needed
    }
  }
}

