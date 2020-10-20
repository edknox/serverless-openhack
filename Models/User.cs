using System;
using Newtonsoft.Json;

namespace BFYOC.Models
{
    public class User
    {    
        [JsonProperty("userId")]    
        public Guid UserId { get; set; } 

        [JsonProperty("userName")]
        public string UserName { get; set; } 

        [JsonProperty("fullName")]
        public string FullName { get; set; } 
    }   
}