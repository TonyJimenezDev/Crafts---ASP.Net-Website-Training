using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crafts.Website.Models;
using Crafts.Website.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Crafts.Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly JsonFileProductsService _productService;

        public IEnumerable<Product> Products { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFileProductsService productsService)
        {
            _logger = logger;
            _productService = productsService;
        }

        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}
