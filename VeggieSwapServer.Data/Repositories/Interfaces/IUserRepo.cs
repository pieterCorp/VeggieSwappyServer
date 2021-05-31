using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwappyServer.Data.Entities;

namespace VeggieSwappyServer.Data.Repositories
{
    public interface IUserRepo
    {
        Task<bool> AddEntityAsync(User entity);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersWithDataAsync();
        Task<bool> UserExistsAsync(string eMail);
    }
}