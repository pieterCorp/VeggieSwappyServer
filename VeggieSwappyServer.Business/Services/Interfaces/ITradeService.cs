using System.Threading.Tasks;
using VeggieSwappyServer.Business.Dto;

namespace VeggieSwappyServer.Business.Services
{
    public interface ITradeService
    {
        Task<TradeDto> GetTradeDto(int trader1, int trader2);
        Task<bool> SaveTradeDto(TradeDto tradeDto);
        Task<TradeHistoryDto> GetTradeHistory(int id);
        Task<bool> CancelTrade(int tradeId);
        Task<bool> AcceptTrade(int tradeId);
    }
}