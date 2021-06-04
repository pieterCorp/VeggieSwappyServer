using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwappyServer.Data.Entities;

namespace VeggieSwappyServer.Data.Repositories
{
    public interface IUserRepo
    {
        Task<bool> AddEntityAsync(User entity);
        Task<IEnumerable<UserTradeItem>> GetAllUserTradeItemsAsync();
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<bool> UserExistsAsync(string eMail);
    }
}