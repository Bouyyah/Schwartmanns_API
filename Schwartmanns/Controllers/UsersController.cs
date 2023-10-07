using Microsoft.AspNetCore.Mvc;
using Schwartmanns.Interfaces;
using Schwartmanns.Models;

namespace Schwartmanns.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _userRepository.CreateUserAsync(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPut("updatePassword/{userId}")]
        public async Task<IActionResult> UpdatePassword(int userId, [FromBody] string newPassword)
        {
            var isUpdated = await _userRepository.UpdatePasswordAsync(userId, newPassword);

            if (!isUpdated)
            {
                return NotFound(); 
            }

            return Ok("Password updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUserAsync(id);
            return NoContent();
        }

        [HttpGet("userDistributionByType")]
        public ActionResult<Dictionary<string, int>> GetUserDistributionByType()
        {
            var userDistribution = _userRepository.GetUserDistributionByType();
            return Ok(userDistribution);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest model)
        {
            var user = await _userRepository.AuthenticateAsync(model.Email, model.Password);

            if (user == null)
            {
                return Unauthorized(); 
            }

            
            return Ok(new
            {
                user.Id,
                user.Name,
                user.Email,
                user.Type       
            });
        }
    }
}
