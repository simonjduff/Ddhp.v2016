using System.ComponentModel.DataAnnotations.Schema;

namespace Ddhp.v2016.Models.Ddhp
{
    [Table("Rounds", Schema = "ddhp")]
    public class Round
    {
        public int Id { get; set; }
        public int RoundNumber { get; set; }
        public int Year { get; set; }
        public bool IsLadderRound { get; set; }
        public bool RoundComplete { get; set; }
    }
}