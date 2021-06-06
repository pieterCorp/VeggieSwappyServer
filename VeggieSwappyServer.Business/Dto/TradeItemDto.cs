namespace VeggieSwappyServer.Business.Dto
{
    public class TradeItemDto
    {
        public int ResourceId { get; set; }

        public string ResourceName { get; set; }

        public string ResourceImageUrl { get; set; }

        public int AvailableAmount { get; set; }

        public int Amount { get; set; }
        
    }
}
