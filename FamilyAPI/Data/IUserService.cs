using System.Security.Claims;
using System.Threading.Tasks;
using Models;
//TODO Make a proper implementation of the UserService with its own version of FileContext for a JSON file.
namespace FamilyAPI.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string password);
        Task RegisterUserAsync(User user);
    }
}