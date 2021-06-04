using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwappyServer.Business.Dto;

namespace VeggieSwappyServer.Business.Services
{
    public interface IUserService1
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<IEnumerable<UserTradeItemDto>> GetAllUserTradeItemssAsync();
        Task<UserDto> GetUserAsync(int id);
        Task<bool> UpdateUserAsync(UserDto model);
    }
}