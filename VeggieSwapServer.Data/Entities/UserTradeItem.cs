using System.ComponentModel.DataAnnotations;

namespace VeggieSwappyServer.Data.Entities
{
    public class UserTradeItem : EntityBase
    {
        [Required]
        public int Amount { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int ResourceId { get; set; }
        public virtual Resource Resource { get; set; }

    }
}
