using System.Threading.Tasks;
using VeggieSwappyServer.Business.Dto;

namespace VeggieSwappyServer.Business.Services
{
    public interface IAccountService
    {
        Task<UserTokenDto> LoginAsync(string eMail, string password);
        Task<UserTokenDto> RegisterAsync(RegisterDto dto);
    }
}