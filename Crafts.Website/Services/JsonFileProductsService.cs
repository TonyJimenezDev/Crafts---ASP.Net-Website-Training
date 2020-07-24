using Crafts.Website.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Crafts.Website.Services
{
    public class JsonFileProductsService
    {
        public IWebHostEnvironment _webHostEnviroment { get; }

        public JsonFileProductsService(IWebHostEnvironment webHostEnviroment)
        {
            _webHostEnviroment = webHostEnviroment;
        }

        private string JsonFileName => Path.Combine(_webHostEnviroment.WebRootPath, "data", "products.json"); // Path wwwroot/Folder/Json

        public IEnumerable<Product> GetProducts()
        {
            // De-serialize the json text
            using StreamReader jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); 
        }

        public void AddRating(string productId, int rating)
        {
            IEnumerable<Product> products = GetProducts();

            Product query = products.FirstOrDefault(x => x.Id == productId);

            if (query.Ratings == null) query.Ratings = new int[] { rating };
            else
            {
                List<int> ratingList = query.Ratings.ToList();
                ratingList.Add(rating);
                query.Ratings = ratingList.ToArray();
            }
            SerializeFile(products);
        }

        private void SerializeFile(IEnumerable<Product> products)
        {
            using FileStream outPutStream = File.Open(JsonFileName, FileMode.Create, FileAccess.Write);
            JsonSerializer.Serialize
                (
                    new Utf8JsonWriter(outPutStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
        }
    }
}
