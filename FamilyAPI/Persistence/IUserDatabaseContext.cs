using System.Threading.Tasks;
using Models;

namespace FamilyAPI.Data
{
    public interface IUserDatabaseContext
    {
        Task RegisterUserAsync(User user);
        Task<User> ValidateUserAsync(string username, string password);
    }
}