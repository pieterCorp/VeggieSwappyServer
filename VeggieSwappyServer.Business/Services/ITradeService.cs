using System.Threading.Tasks;
using VeggieSwappyServer.Business.Dto;

namespace VeggieSwappyServer.Business.Services
{
    public interface ITradeService
    {
        Task<TradeDto> CreateTradeDto(int trader1, int trader2);
        Task<TradeDto> GetTradeDto(int trader1, int trader2);
        Task<bool> SaveTradeDto(TradeDto tradeDto);
    }
}