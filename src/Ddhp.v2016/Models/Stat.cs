using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Ddhp.v2016.Models.Ddhp;

namespace Ddhp.v2016.Models
{
    [Table("Stats")]
    public class Stat
    {
        public int Id { get; set; }
        public virtual Round Round { get; set; }
        public virtual Player Player { get; set; }
        public int RoundId { get; set; }
        public int PlayerId { get; set; }
        public int Goals { get; set; }
        public int Behinds { get; set; }
        public int Disposals { get; set; }
        public int Marks { get; set; }
        public int Hitouts { get; set; }
        public int Tackles { get; set; }
        public int Kicks { get; set; }
        public int Handballs { get; set; }
        public int GoalAssists { get; set; }
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        public int Inside50s { get; set; }
        public int FreesFor { get; set; }
        public int FreesAgainst { get; set; }
        public int AflClubId { get; set; }
        public virtual Afl.Club AflClub { get; set; }
    }
}