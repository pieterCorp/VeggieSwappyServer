using System.Collections.Generic;
using VeggieSwappyServer.Business.MappedModels;

namespace VeggieSwappyServer.Business.Dto
{
    public class TradeHistoryDto
    {
        public int Id { get; set; }
        public bool Completed { get; set; }
        public int TimesRejected { get; set; }
        public int User1_Id { get; set; }
        public string User1_FirstName { get; set; }
        public string User1_LastName { get; set; }

        public int User2_Id { get; set; }
        public string User2_FirstName { get; set; }
        public string User2_LastName { get; set; }

        public TradeProposalModel CurrentTradeProposal { get; set; }
        public ICollection<TradeProposalModel> RejectedTradeProposals { get; set; }
    }
}
