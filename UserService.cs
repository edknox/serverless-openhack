using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BFYOC.Models;
using Newtonsoft.Json;

namespace BFYOC
{
    public class UserService
    {
        private static User[] users = new User[]
        {
            new User{
                UserId = new Guid("cc20a6fb-a91f-4192-874d-132493685376"),
                UserName = "doreen.riddle",
                FullName = "Doreen Riddle",
            }
        };
        
        static readonly HttpClient client = new HttpClient();
        private static readonly string GetUserUrl = "https://serverlessohuser.trafficmanager.net/api/GetUser";

        public async Task<User> GetUserAsync(Guid userId)
        {            
            var response = await client.GetAsync($"{GetUserUrl}?userId={userId}");            
            if(response.StatusCode == System.Net.HttpStatusCode.BadRequest 
            || response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            var responseBody = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(responseBody);

            return user;
        }  
    }
}