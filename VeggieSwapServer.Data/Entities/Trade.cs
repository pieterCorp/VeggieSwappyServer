using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeggieSwappyServer.Data.Entities
{
    public class Trade : EntityBase
    {
        [ForeignKey("User")]
        public int User1Id { get; set; }
       
        [ForeignKey("User")]
        public int User2Id { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<RejectedTradeProposal> RejectedTradeProposals { get; set; }       

        public virtual CurrentTradeProposal CurrentTradeProposal { get; set; }

        public bool Completed { get; set; }

    }
}
