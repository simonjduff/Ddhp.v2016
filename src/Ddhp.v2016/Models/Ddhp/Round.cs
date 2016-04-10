using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ddhp.v2016.Models.Ddhp
{
    [Table("Rounds", Schema = "ddhp")]
    public class Round
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int RoundNumber { get; set; }
        public int Year { get; set; }
        public bool IsLadderRound { get; set; }
        public bool Complete { get; set; }
    }
}