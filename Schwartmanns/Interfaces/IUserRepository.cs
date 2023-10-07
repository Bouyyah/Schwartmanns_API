using Schwartmanns.Models;

namespace Schwartmanns.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdatePasswordAsync(int userId, string newPassword);
        Task DeleteUserAsync(int id);

        Task<User> AuthenticateAsync(string email, string password);
        Dictionary<string, int> GetUserDistributionByType();
    }
}
