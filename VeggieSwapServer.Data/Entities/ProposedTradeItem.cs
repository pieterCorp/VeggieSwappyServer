using System.ComponentModel.DataAnnotations;

namespace VeggieSwappyServer.Data.Entities
{
    public class ProposedTradeItem : EntityBase
    {
        [Required]
        public int Amount { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }
        public int? CurrentTradeProposalId { get; set; }
        public CurrentTradeProposal CurrentTradeProposal { get; set; }
        public int? RejectedTradeProposalId { get; set; }
        public RejectedTradeProposal RejectedTradeProposal { get; set; }
    }
}
