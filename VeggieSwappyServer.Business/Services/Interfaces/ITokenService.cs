using VeggieSwappyServer.Data.Entities;

namespace VeggieSwappyServer.Business.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}