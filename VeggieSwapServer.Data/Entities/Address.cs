using System.ComponentModel.DataAnnotations;

namespace VeggieSwappyServer.Data.Entities
{
    public class Address : EntityBase
    {
      
        [Required]
        [StringLength(50)]
        public string StreetName { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        public int PostalCode { get; set; }

        public float? longitude { get; set; }
        public float? latitude { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
