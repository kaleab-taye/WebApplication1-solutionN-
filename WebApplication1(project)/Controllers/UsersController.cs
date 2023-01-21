using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1_project_.Data;
using WebApplication1_project_.Models;

namespace WebApplication1_project_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly UsersAPIDbContext dbContext;

        public UsersController(UsersAPIDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await dbContext.Users.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers(AddUserRequest addUserRequest)
        {
            var user = new User()
            {
                UserID = Guid.NewGuid(),
                Name = addUserRequest.Name,
                Email = addUserRequest.Email,
                Phone = addUserRequest.Phone,
                AuthId = addUserRequest.AuthId

            };

            await dbContext.Users.AddAsync(user); 
            await dbContext.SaveChangesAsync();

            return Ok(user);

        }
    }
}
