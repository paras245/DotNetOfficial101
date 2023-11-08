using ConstosoCrafts.Websites.Models;
using ConstosoCrafts.Websites.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstosoCrafts.Websites.Controllers
{
    [Route("[controller]")]
    [ApiController]

    //Acces Modifier Controller Name 
    public class ProductsController : ControllerBase
    {

        //Access-Modifier Constructor 
        public ProductsController(JsonFileProductService productService)
        {
            //Dependency Injection
            this.ProductService = productService;
        }

        //Access-Modifier 
        public JsonFileProductService ProductService { get; }


        //Http Verb : It is a get method
        [HttpGet]
        //Access Modifier 
        public IEnumerable<Product> Get()
        {
            return ProductService.GetProducts();
        }


        //[HttpPatch]
        [Route("Rate")]
        //Action Verb
        [HttpGet]
        public ActionResult Get([FromQuery] string ProductId,[FromQuery] int Rating)
        {
           ProductService.AddRating(ProductId, Rating);

           //Return 200
           return Ok();
        }
    }
}
