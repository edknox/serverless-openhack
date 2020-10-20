using System;
using BFYOC.Models;

namespace BFYOC
{
    public class RatingService
    {
        public CreateRatingResponse Create(CreateRatingRequest request)
        {
            // call into cosmos to create the rating for the given product
            var response = new CreateRatingResponse(request);
            response.Id = Guid.NewGuid();
            response.TimeStamp = DateTime.UtcNow;
            return response;
        }
    }
}