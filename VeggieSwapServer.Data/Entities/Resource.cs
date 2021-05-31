using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace VeggieSwappyServer.Data.Entities
{
    public class Resource : EntityBase
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string ImageUrl { get; set; }        
        public virtual ICollection<UserTradeItem> UserTradeItems { get; set; }
    }
}
