using System.ComponentModel.DataAnnotations.Schema;

namespace Ddhp.v2016.Models.Afl
{
    [Table("Clubs", Schema = "afl")]
    public class Club
    {
        public int Id { get; set; }
        public string ClubName { get; set; } 
        public string ShortClubName { get; set; }
    }
}