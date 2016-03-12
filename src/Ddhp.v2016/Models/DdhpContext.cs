using Ddhp.v2016.Models.Ddhp;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace Ddhp.v2016.Models
{
    public class DdhpContext : DbContext, IDdhpContext
    {
        public DdhpContext()
        {
            
        }

        public DdhpContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; } 

        public DbSet<Stat> Stats { get; set; }
        public DbSet<Afl.Club> AflClubs { get; set; }
        public DbSet<Ddhp.Club> DdhpClubs { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Round> Rounds { get; set; }
    }
}