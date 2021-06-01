using System.Collections.Generic;
using VeggieSwappyServer.Business.Dto;

namespace VeggieSwappyServer.Business.MappedModels
{
    public class TradeProposalModel
    {        
        public int ProposingUserId { get; set; }
        public ICollection<TradeItemDto> ProposedTradeItems { get; set; }
    }
}
