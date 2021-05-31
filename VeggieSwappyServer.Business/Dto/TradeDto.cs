using System.Collections.Generic;

namespace VeggieSwappyServer.Business.Dto
{
    public class TradeDto
    {
        public int Id { get; set; }
        public int ProposingUserId { get; set; }

        public int User1_Id { get; set; }
        public string User1_FirstName { get; set; }
        public string User1_LastName { get; set; }

        public int User2_Id { get; set; }
        public string User2_FirstName { get; set; }
        public string User2_LastName { get; set; }

        public IEnumerable<TradeItemDto> TradeItemsUser1 { get; set; }
        public IEnumerable<TradeItemDto> TradeItemsUser2 { get; set; }

        public IEnumerable<TradeItemDto> ProposedTradeItemsUser1 { get; set; }
        public IEnumerable<TradeItemDto> ProposedTradeItemsUser2 { get; set; }
    }
}
