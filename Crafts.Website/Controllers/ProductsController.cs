using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crafts.Website.Models;
using Crafts.Website.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crafts.Website.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly JsonFileProductsService _productsService;

        public ProductsController(JsonFileProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productsService.GetProducts();
        }
    }
}
