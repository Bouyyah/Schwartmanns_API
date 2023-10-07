using Microsoft.EntityFrameworkCore;
using Schwartmanns.Data;
using Schwartmanns.Interfaces;
using Schwartmanns.Models;

namespace Schwartmanns.Repositories
{
   
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.OrderBy(u => u.Id).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash, salt);

            user.PasswordHash = hashedPassword;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UpdatePasswordAsync(int userId, string newPassword)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return false; 
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword); 

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        
       

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public Dictionary<string, int> GetUserDistributionByType()
        {
            var result = _context.Users
                .GroupBy(u => u.Type)
                .Select(group => new
                {
                    UserType = group.Key,
                    Count = group.Count()
                })
                .ToDictionary(x => x.UserType, x => x.Count);

            return result;
        }

        public async Task<User> AuthenticateAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !VerifyPasswordHash(password, user.PasswordHash))
            {
                return null; 
            }

            return user; 
        }

        
        private bool VerifyPasswordHash(string password, string storedHash)
        {
            
             return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
    
}
