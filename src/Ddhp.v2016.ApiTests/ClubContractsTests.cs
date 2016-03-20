using System.Linq;
using Ddhp.v2016.Models;
using Ddhp.v2016.Models.Ddhp;
using Xunit;

namespace Ddhp.v2016.ApiTests
{
    public class ClubContractsTests : InMemoryTestsBase
    {
        public ClubContractsTests()
        {
            var club = new Club {Name = "Club1", CoachName = "Coach1"};
            var player1 = new Player { FirstName = "First1", LastName = "Second1" };
            DdhpContext.Players.Add(player1);
            var player2 = new Player { FirstName = "First2", LastName = "Second2" };
            DdhpContext.Players.Add(player2);

            player1.Stats.Add(new Stat());
            player2.Stats.Add(new Stat());
            player2.Stats.Add(new Stat());
            DdhpContext.DdhpClubs.Add(club);
        }

        [Fact]
        public void AveragesAreCorrect()
        {
            Assert.Equal(3, DdhpContext.Stats.Count());
            Assert.Equal(12, DdhpContext.DdhpClubs.Count());
        }
    }
}