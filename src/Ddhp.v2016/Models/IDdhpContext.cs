using Ddhp.v2016.Models.Ddhp;
using Microsoft.Data.Entity;

namespace Ddhp.v2016.Models
{
    public interface IDdhpContext
    {
        DbSet<Player> Players { get; set; }
        DbSet<Stat> Stats { get; set; }
        DbSet<Afl.Club> AflClubs { get; set; }
        DbSet<Ddhp.Club> DdhpClubs { get; set; }
        DbSet<Contract> Contracts { get; set; }
        DbSet<Round> Rounds { get; set; }
    }
}