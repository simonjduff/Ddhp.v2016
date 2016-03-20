using System.Linq;
using Ddhp.v2016.Models;
using Xunit;

namespace Ddhp.v2016.ApiTests
{
    [Collection("InMemory")]
    public class ClubContractsTests : InMemoryTestsBase
    {
        public ClubContractsTests()
        {
            var player1 = new Player { FirstName = "First1", LastName = "Second1" };
            DdhpContext.Players.Add(player1);
            var player2 = new Player { FirstName = "First2", LastName = "Second2" };
            DdhpContext.Players.Add(player2);

            DdhpContext.Stats.Add(new Stat { Player = player1 });
            DdhpContext.Stats.Add(new Stat { Player = player2 });
            DdhpContext.Stats.Add(new Stat { Player = player2 });

            DdhpContext.SaveChanges();
        }

        [Fact]
        public void AveragesAreCorrect()
        {
            Assert.Equal(3, DdhpContext.Stats.Count());
            Assert.Equal(12, DdhpContext.DdhpClubs.Count());
        }
    }
}