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
    }
}