using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwappyServer.Business.Dto;
using VeggieSwappyServer.Data.Entities;

namespace VeggieSwappyServer.Business.Services
{
    public interface IUserService : IGenericService<User, UserDto>
    { 
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<IEnumerable<UserTradeItemDto>> GetAllUserTradeItemssAsync();
        Task<UserDto> GetUserAsync(int id);
        Task<bool> UpdateUserAsync(UserDto model);
    }
}