namespace VeggieSwappyServer.Business.Dto
{
    public class UserTradeItemDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPostalCode { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public string ResourceImageUrl { get; set; }
        public int Amount { get; set; }        
    }
}
