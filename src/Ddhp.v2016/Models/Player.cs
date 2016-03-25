using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ddhp.v2016.Models
{
    [Table("Players")]
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleNames { get; set; }
        public virtual ICollection<Stat> Stats { get; set; }
        public bool Retired { get; set; }
        public virtual Afl.Club CurrentAflClub { get; set; }
        public int CurrentAflClubId { get; set; }
    }
}