
using System;
using Newtonsoft.Json;

namespace BFYOC.Models
{    
    public class CreateRatingResponse : CreateRatingRequest
    {
        [JsonProperty("id")]
        public Guid Id{get;set;}

        [JsonProperty("timestamp")]
        public DateTime TimeStamp{get;set;}

        public CreateRatingResponse(){}
        
        public CreateRatingResponse(CreateRatingRequest request)
        {
            this.LocationName = request.LocationName;            
            this.ProductId = request.ProductId;
            this.Rating = request.Rating;
            this.UserId = request.UserId;
            this.UserNotes = request.UserNotes;
        }        
    }
}