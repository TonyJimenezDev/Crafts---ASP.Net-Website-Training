using Crafts.Website.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Crafts.Website.Services
{
    public class JsonFileProductsService
    {
        public IWebHostEnvironment _webHostEnviroment { get; }

        public JsonFileProductsService(IWebHostEnvironment webHostEnviroment) => _webHostEnviroment = webHostEnviroment;

        private string JsonFileName => Path.Combine(_webHostEnviroment.WebRootPath, "data", "products.json"); // Path wwwroot/Folder/Json

        public IEnumerable<Product> GetProducts()
        {
            // De-serialize the json text
            using StreamReader jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); 
        }
    }
}
