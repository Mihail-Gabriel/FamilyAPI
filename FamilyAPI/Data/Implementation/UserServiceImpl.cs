using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileData;
using Models;

namespace FamilyAPI.Data.Implementation
{
    public class UserServiceImpl : IUserService
    {
        private List<User> users;
        private IUserDatabaseContext databaseContext;
        public UserServiceImpl()
        {
            databaseContext = new UserDatabaseContext();
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
            Console.WriteLine(userName);
            Console.WriteLine(password);
            return await databaseContext.ValidateUserAsync(userName, password);
        }

    public async Task RegisterUserAsync(User user)
    {
        await databaseContext.RegisterUserAsync(user);
    }
    }
    
}