using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BFYOC.Models
{
    public class Product
    {
        [JsonProperty("productId")]
        public Guid ProductId{get;set;}
        [JsonProperty("productName")]
        public string ProductName{get;set;}
        [JsonProperty("productDescription")]
        public string ProductDescription{get;set;}
    }
}
