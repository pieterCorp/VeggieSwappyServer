using System.Threading.Tasks;
using VeggieSwappyServer.Business.Dto;
using VeggieSwappyServer.Data.Entities;

namespace VeggieSwappyServer.Business.Services
{
    public class TradeService 
    {

        public async Task<bool> SaveTradeDto(TradeDto tradeDto)
        {
            if (tradeDto.Id == 0)
            {
                //create new trade
            }
            else
            {
                //await UpdateExistingTrade(tradeDto);
            }
            return true;
        }
    }
}
