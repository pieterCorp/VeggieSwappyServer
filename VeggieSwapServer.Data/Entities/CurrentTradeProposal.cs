using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeggieSwappyServer.Data.Entities
{
    public class CurrentTradeProposal : EntityBase
    {
        public int ProposingUserId { get; set; }

        [ForeignKey("Trade")]
        public int TradeId { get; set; }
        public virtual Trade Trade { get; set; }
        public virtual ICollection<ProposedTradeItem> ProposedTradeItems { get; set; }

    }
}
