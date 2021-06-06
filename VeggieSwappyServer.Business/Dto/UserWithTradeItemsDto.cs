using System.Collections.Generic;

namespace VeggieSwappyServer.Business.Dto
{
    public class UserWithTradeItemsDto
    {
        public UserDto User { get; set; }

        public IEnumerable<TradeItemDto> TradeItems { get; set; }
    }
}
