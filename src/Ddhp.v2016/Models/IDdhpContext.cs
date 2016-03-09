using Microsoft.Data.Entity;

namespace Ddhp.v2016.Models
{
    public interface IDdhpContext
    {
        DbSet<Player> Players { get; set; }
    }
}