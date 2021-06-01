using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeggieSwappyServer.Business.Dto;
using VeggieSwappyServer.Data.Entities;
using VeggieSwappyServer.Data.Enums;
using VeggieSwappyServer.Data.Repositories;

namespace VeggieSwappyServer.Business.Services
{
    public class TradeService : GenericService<Trade, TradeDto>, ITradeService
    {
        private readonly ITradeRepo _tradeRepo;
        private readonly IUserRepo _userRepo;

        public TradeService(IGenericRepo<Trade> genericRepo, ITradeRepo tradeRepo, IMapper mapper, IUserRepo userRepo)
            : base(genericRepo, mapper)
        {
            _tradeRepo = tradeRepo;
            _userRepo = userRepo;
        }
        public async Task<TradeDto> GetTradeDto(int trader1, int trader2)
        {
            Trade trade = await _tradeRepo.GetTradeAsync(trader1, trader2);

            if (trade != null && trade.Users.Count == 2) 
                return _mapper.Map<TradeDto>(trade);
           
            return await CreateTradeDto(trader1, trader2);
        }
        public async Task<bool> SaveTradeDto(TradeDto tradeDto)
        {
            if (tradeDto.Id == 0)
            {
                Trade trade = await CreateNewTrade(tradeDto);
                await _genericRepo.AddEntityAsync(trade);
            }
            else
            {
                await UpdateExistingTrade(tradeDto);
            }
            return true;
        }
        public async Task<TradeHistoryDto> GetTradeHistory(int id)
        {
            Trade trade = await _tradeRepo.GetTradeWithHistoryByIdAsync(id);
            return _mapper.Map<TradeHistoryDto>(trade);
        }

        public async Task<bool> CancelTrade(int tradeId)
        {
            Trade trade = await _tradeRepo.GetTradeByIdAsync(tradeId);
            trade.TradeStatus = TradeStatus.CANCELED;
            await _genericRepo.UpdateEntityAsync(trade);
            return true;
        }

        private async Task<TradeDto> CreateTradeDto(int trader1, int trader2)
        {
            User user1 = await _userRepo.GetUserByIdAsync(trader1);
            User user2 = await _userRepo.GetUserByIdAsync(trader2);

            TradeDto tradeDTO = new()
            {
                ProposingUserId = trader1,
                User1_Id = trader1,
                User1_FirstName = user1.FirstName,
                User1_LastName = user1.LastName,
                User2_Id = trader2,
                User2_FirstName = user2.FirstName,
                User2_LastName = user2.LastName,
                TradeItemsUser1 = _mapper.Map<ICollection<TradeItemDto>>(user1.UserTradeItems),
                TradeItemsUser2 = _mapper.Map<ICollection<TradeItemDto>>(user2.UserTradeItems)
            };
            return tradeDTO;
        }

        private async Task UpdateExistingTrade(TradeDto tradeDto)
        {
            Trade trade = await _tradeRepo.GetTradeByIdAsync(tradeDto.Id);
            RejectedTradeProposal rejectedProposal = _mapper.Map<RejectedTradeProposal>(trade.CurrentTradeProposal);

            if (trade.RejectedTradeProposals == null)
                trade.RejectedTradeProposals = new List<RejectedTradeProposal>();

            trade.RejectedTradeProposals.Add(rejectedProposal);
            trade.CurrentTradeProposal = MakeNewTradeProposal(tradeDto);

            await _genericRepo.UpdateEntityAsync(trade);
        }

        private CurrentTradeProposal MakeNewTradeProposal(TradeDto tradeDto)
        {
            CurrentTradeProposal newProposal = new()
            {
                ProposedTradeItems = HardCloneTradeItems(tradeDto),
                ProposingUserId = tradeDto.ProposingUserId,
                TradeId = tradeDto.Id
            };

            return newProposal;
        }

        private List<ProposedTradeItem> HardCloneTradeItems(TradeDto tradeDto)
        {
            List<ProposedTradeItem> clonedTradeItems = new();

            foreach (var tradeItem in tradeDto.ProposedTradeItemsUser1)
            {
                ProposedTradeItem newTradeItem = new()
                {
                    Amount = tradeItem.Amount,
                    UserId = tradeDto.User1_Id,
                    ResourceId = tradeItem.ResourceId,
                };
                clonedTradeItems.Add(newTradeItem);
            }

            foreach (var tradeItem in tradeDto.ProposedTradeItemsUser2)
            {
                ProposedTradeItem newTradeItem = new()
                {
                    Amount = tradeItem.Amount,
                    UserId = tradeDto.User2_Id,
                    ResourceId = tradeItem.ResourceId,
                };
                clonedTradeItems.Add(newTradeItem);
            }
            return clonedTradeItems;
        }

        private async Task<Trade> CreateNewTrade(TradeDto tradeDto)
        {
            User user1 = await _userRepo.GetUserByIdAsync(tradeDto.User1_Id);
            User user2 = await _userRepo.GetUserByIdAsync(tradeDto.User2_Id);

            Trade trade = new()
            {
                User1Id = user1.Id,
                User2Id = user2.Id,
                TradeStatus = TradeStatus.ACTIVE,
            };
            List<User> users = new()
            {
                user1,
                user2
            };
            trade.Users = users;
            trade.CurrentTradeProposal = MakeNewTradeProposal(tradeDto);

            return trade;
        }
    }
}
