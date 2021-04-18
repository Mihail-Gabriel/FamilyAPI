using System;
using System.Threading.Tasks;
using FamilyAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace FamilyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUserAsync([FromQuery]string userName,[FromQuery] string password)
        {
            try
            {
               User user = await  UserService.ValidateUserAsync(userName,password);
               return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}