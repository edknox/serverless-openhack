using System;
using System.Linq;
using BFYOC.Models;

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
        public User GetUser(Guid userId)
        {
            return users.FirstOrDefault(x=>x.UserId == userId);    
        }
    }
}