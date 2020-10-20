
using System;
using Newtonsoft.Json;

namespace BFYOC.Models
{    
    public class CreateRatingRequest
    {
        [JsonProperty("userId")]
        public string UserId{get;set;}

        [JsonProperty("productId")]
        public string ProductId{get;set;}

        [JsonProperty("locationName")]
        public string LocationName{get;set;}

        [JsonProperty("rating")]
        public int Rating{get;set;}

        [JsonProperty("userNotes")]
        public string UserNotes{get;set;}
    }
}