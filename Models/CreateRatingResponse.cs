
using System;

namespace BFYOC.Models
{    
    public class CreateRatingResponse : CreateRatingRequest
    {
        public Guid Id{get;set;}
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