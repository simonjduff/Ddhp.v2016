using System.ComponentModel.DataAnnotations.Schema;
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
    }
}