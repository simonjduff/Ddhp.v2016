using System.ComponentModel.DataAnnotations.Schema;

namespace Ddhp.v2016.Models.Ddhp
{
    [Table("Clubs", Schema="ddhp")]
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoachName { get; set; } 
    }
}