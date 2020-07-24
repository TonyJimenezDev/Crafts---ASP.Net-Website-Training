using Crafts.Website.Models;
using Crafts.Website.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Crafts.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly JsonFileProductsService _productsService;

        public ProductsController(JsonFileProductsService productsService) => _productsService = productsService;


        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _productsService.GetProducts();
        }

        [Route("Rate")]
        [HttpPut]
        public ActionResult PutRatings([FromQuery] string productId, int rating)
        {
            if (productId == null) return NotFound();
            _productsService.AddRating(productId, rating);
            return Ok();
        }
    }
}
