using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwappyServer.Data.Entities;

namespace VeggieSwappyServer.Data.Repositories
{
    public interface ITradeRepo
    {
        Task<Trade> GetTradeAsync(int trader1, int trader2);
        Task<Trade> GetTradeByIdAsync(int id);
        Task<int> GetTradeIdAsync(int trader1, int trader2);
        Task<IEnumerable<Trade>> GetTradesAsync();
    }
}