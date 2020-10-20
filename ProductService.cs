using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using BFYOC.Models;
using System.Net.Http;

namespace BFYOC
{
    public class ProductService
    {
        static readonly HttpClient client = new HttpClient();
        private static readonly string GetProductsUrl = "https://serverlessohproduct.trafficmanager.net/api/GetProducts";
        private static readonly string GetProductUrl = "https://serverlessohproduct.trafficmanager.net/api/GetProduct";

        private static Product[] products = new Product[]{
                new Product{
                    ProductId= new Guid("75542e38-563f-436f-adeb-f426f1dabb5c"),
                    ProductName= "Starfruit Explosion",
                    ProductDescription= "This starfruit ice cream is out of this world!"},
                new Product{
                    ProductId= new Guid("288fd748-ad2b-4417-83b9-7aa5be9cff22"),
                    ProductName= "Tropical Mango",
                    ProductDescription= "You know what they say... It takes two.  You.  And this ice cream."
                },
                new Product{    
                    ProductId= new Guid("76065ecd-8a14-426d-a4cd-abbde2acbb10"),
                    ProductName= "Gone Bananas",
                    ProductDescription= "I'm not sure how appealing banana ice cream really is."},
                new Product{
                    ProductId= new Guid("4c25613a-a3c2-4ef3-8e02-9c335eb23204"),
                    ProductName ="Truly Orange-inal",
                    ProductDescription="Made from concentrate."
                }                
            };

        public async Task<Product> GetProductAsync(Guid productId)
        {            
            var response = await client.GetAsync($"{GetProductUrl}?productId={productId}");            
            if(response.StatusCode == System.Net.HttpStatusCode.BadRequest 
            || response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            var responseBody = await response.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<Product>(responseBody);

            return product;
        }   

        public Product[] GetProducts()
        {
            return products;            
        }
    }
}
