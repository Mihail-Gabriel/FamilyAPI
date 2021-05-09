using System.Linq;
using System.Threading.Tasks;
using FamilyAPI.Data;
using FamilyAPI.DataAccess;
using Models;

namespace FileData
{
    public class UserDatabaseContext : IUserDatabaseContext
    {
        public async Task RegisterUserAsync(User user)
        {
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                await dbContext.AddAsync(user);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            using (FamilyDbContext dbContext = new FamilyDbContext())
            {
                User user = dbContext.Users.FirstOrDefault(u => (u.UserName == username || u.Password == password));
                return user;
            }
        }
    }
}