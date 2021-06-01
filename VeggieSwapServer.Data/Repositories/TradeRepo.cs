using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VeggieSwappyServer.Data.Entities;
using VeggieSwappyServer.Data.Enums;

namespace VeggieSwappyServer.Data.Repositories
{
    public class TradeRepo : GenericRepo<Trade>, ITradeRepo
    {
        public TradeRepo(VeggieSwappyServerContext context)
            : base(context)
        {
        }

        public async Task<Trade> GetTradeAsync(int trader1, int trader2)
        {
             return await _context.Trades
                    .Where(x => x.User1Id == trader1 | x.User1Id == trader2)
                    .Where(x => x.User2Id == trader1 | x.User2Id == trader2)
                    .Include(x => x.Users)
                    .ThenInclude(x => x.UserTradeItems)
                    .ThenInclude(x => x.Resource)
                    .Include(x => x.CurrentTradeProposal)
                    .ThenInclude(x => x.ProposedTradeItems)
                    .ThenInclude(x => x.Resource)
                    .FirstOrDefaultAsync(y => y.TradeStatus == TradeStatus.ACTIVE);
        }

        public async Task<Trade> GetTradeByIdAsync(int id)
        {
           return await _context.Trades
                    .Where(x => x.Id == id)
                    .Include(x => x.Users)
                    .ThenInclude(x => x.UserTradeItems)
                    .ThenInclude(x => x.Resource)
                    .Include(x => x.CurrentTradeProposal)
                    .ThenInclude(x => x.ProposedTradeItems)
                    .ThenInclude(x => x.Resource)               
                    .FirstOrDefaultAsync(y => y.TradeStatus == TradeStatus.ACTIVE);
        }

        public async Task<Trade> GetTradeWithHistoryByIdAsync(int id)
        {
            return await _context.Trades
                    .Where(x => x.Id == id)
                    .Include(x => x.Users)              
                    .Include(x => x.RejectedTradeProposals)
                    .ThenInclude(x => x.ProposedTradeItems)
                    .ThenInclude(x => x.Resource)
                    .Include(x => x.CurrentTradeProposal)
                    .ThenInclude(x => x.ProposedTradeItems)
                    .ThenInclude(x => x.Resource)
                    .FirstOrDefaultAsync();
        }

        public async Task<int> GetTradeIdAsync(int trader1, int trader2)
        {
            Trade trade = await GetTradeAsync(trader1, trader2);
            return trade.Id;
        }

        public async Task<IEnumerable<Trade>> GetTradesAsync()
        {
            return await _context.Trades
                .Include(x => x.Users)
                .ToListAsync();
        }
    }
}
