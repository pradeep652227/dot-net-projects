using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsoleToWebAPI.Repositories;
using ConsoleToWebAPI.Models;
namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _prodRepo;//created an instance of ProductRepo

        public ProductsController(IProductRepo productRepo)//crate the dependency b/w the controller and interface
        {
            _prodRepo = productRepo;//only single instance of this repo is created
        }
        [HttpPost("")]
        public IActionResult AddProduct([FromBody]ProductModel prod)
        {
            _prodRepo.AddProduct(prod);
            var prods = _prodRepo.GetAllProducts();
            return Ok(prods);
        }
    }
}
