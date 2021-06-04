using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VeggieSwappyServer.Data.Entities
{
    public class User : EntityBase
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        public bool IsAdmin { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<UserTradeItem> UserTradeItems { get; set; }
        public virtual ICollection<Trade> Trades { get; set; }

    }
}
