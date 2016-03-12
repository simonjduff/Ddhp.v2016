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
            var player1 = new Player {FirstName = "P1", LastName = "PL1"};
            DdhpContext.DdhpClubs.Add(club);
        }

        [Fact]
        public void AveragesAreCorrect()
        {
            
        }
    }
}