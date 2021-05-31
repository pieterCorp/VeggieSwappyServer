using Microsoft.EntityFrameworkCore;
using VeggieSwappyServer.Data.Entities;

namespace VeggieSwappyServer.Data
{
    public class VeggieSwappyServerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<UserTradeItem> UserTradeItems { get; set; }
        public DbSet<ProposedTradeItem> ProposedTradeItems { get; set; }
        public DbSet<CurrentTradeProposal> CurrentTradeProposals { get; set; }
        public DbSet<RejectedTradeProposal> rejectedTradeProposals { get; set; }
        public DbSet<Trade> Trades { get; set; }

        public VeggieSwappyServerContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
