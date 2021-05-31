using System.Collections.Generic;

namespace VeggieSwappyServer.Data.Entities
{
    public class RejectedTradeProposal : EntityBase
    {
        public int ProposingUserId { get; set; }        
        public int TradeId { get; set; }
        public virtual Trade Trade { get; set; }
        public virtual ICollection<ProposedTradeItem> ProposedTradeItems { get; set; }

    }
}
