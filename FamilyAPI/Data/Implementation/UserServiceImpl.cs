using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace FamilyAPI.Data.Implementation
{
    public class UserServiceImpl : IUserService
    {
        private List<User> users;

        public UserServiceImpl()
        {
            users = new[]
            {
                new User
                {
                    UserName = "Mihail",
                    Password = "12345",
                    Role = "Adult"
                },
                new User()
                {
                    UserName= "Gabriel",
                    Password = "12345",
                    Role = "Child"
                }
            }.ToList();
        }
    

    public async Task<User> ValidateUserAsync(string userName, string password)
        {
            Console.WriteLine(userName + "\n");
            Console.WriteLine(password);
            User first =  users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
    
}