using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BFYOC.Models;

namespace BFYOC
{

    public static class CreateRating
    {
        private static readonly ProductService productService = new ProductService();
        private static readonly UserService userService = new UserService();
        private static readonly RatingService ratingService = new RatingService();
        
        [FunctionName("CreateRating")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Create Rating function called");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var createRatingRequest = JsonConvert.DeserializeObject<CreateRatingRequest>(requestBody);

            // validate the product id is a guid
            if (!Guid.TryParse(createRatingRequest.ProductId, out Guid productId))
                return new BadRequestObjectResult("ProductId is not a guid");

            // validate the product exists
            var product = productService.GetProduct(productId);
            if (product == null)
                return new NotFoundObjectResult($"product {productId} was not found");

            // validate user id is a guid
            if (!Guid.TryParse(createRatingRequest.ProductId, out Guid userId))
                return new BadRequestObjectResult("UserId is not a guid");

            // validate the user exists
            var user = userService.GetUser(userId);
            if(user == null)
                return new NotFoundObjectResult($"user {userId} was not found");            

            // validate rating is between 0 and 5
            if(createRatingRequest.Rating < 0 || createRatingRequest.Rating > 5)
                return new BadRequestObjectResult("Rating must be a value between 0 and 5");

            var response = ratingService.Create(createRatingRequest);
            return new CreatedResult("ratings", response);
        }
    }
}
