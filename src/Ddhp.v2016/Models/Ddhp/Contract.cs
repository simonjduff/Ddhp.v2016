using System.ComponentModel.DataAnnotations.Schema;

namespace Ddhp.v2016.Models.Ddhp
{
    [Table("Contracts", Schema = "ddhp")]
    public class Contract
    {
        public int Id { get; set; }
        public virtual Player Player { get; set; }
        public int PlayerId { get; set; } 
        public Round FromRound { get; set; }
        public int FromRoundId { get; set; }
        public Round ToRound { get; set; }
        public int ToRoundId { get; set; }
        public virtual Club Club { get; set; }
        public int ClubId { get; set; }
    }
}