using ConstosoCrafts.Websites.Models;
using ConstosoCrafts.Websites.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstosoCrafts.Websites.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            this.ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }

        //[HttpPatch]
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string ProductId,[FromQuery] int Rating)
        {
           ProductService.AddRating(ProductId, Rating);
           return Ok();
        }
    }
}
