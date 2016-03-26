using System.Collections.Generic;
using Ddhp.v2016.ApiTests.DataSources;
using Ddhp.v2016.Models;
using Ddhp.v2016.Models.Ddhp;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Ddhp.v2016.ApiTests
{
    public class ClubContractsTests : InMemoryTestsBase
    {
        public ClubContractsTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async void GetCurrentContractsForClub()
        {
            // Given it is round 5 2012
            var round = 201205;

            // And I am the Cheats
            var teamName = "Cheats";

            // When I request Contracts
            var url = $"/api/contracts/{round}/{teamName}";
            var results = (await GetResults<List<Contract>>(url)).ToList();

            // Then I have 24 contracts
            Assert.Equal(24, results.Count);

            // And the Players are loaded
            var expectedPlayers = new[]{
                new {FirstName = "Cameron", LastName = "Bruce",     FromRoundId = 201101, ToRoundId = 201210},
                new {FirstName = "Andrew",  LastName = "Swallow",   FromRoundId = 201201, ToRoundId = 201224},
                new {FirstName = "Scott",   LastName = "Pendlebury",FromRoundId = 201201, ToRoundId = 201224},
                new {FirstName = "Jared",   LastName = "Brennan",   FromRoundId = 201101, ToRoundId = 201324},
                new {FirstName = "Jarrad",  LastName = "McVeigh",   FromRoundId = 201201, ToRoundId = 201424},
                new {FirstName = "Brent",   LastName = "Stanton",   FromRoundId = 201201, ToRoundId = 201224},
                new {FirstName = "Kade",    LastName = "Simpson",   FromRoundId = 201101, ToRoundId = 201224},
                new {FirstName = "Adam",    LastName = "Schneider", FromRoundId = 201101, ToRoundId = 201224},
                new {FirstName = "Jarrod",  LastName = "Harbrow",   FromRoundId = 201101, ToRoundId = 201211},
                new {FirstName = "Robert",  LastName = "Warnock",   FromRoundId = 201201, ToRoundId = 201224},
                new {FirstName = "Jack",    LastName = "Riewoldt",  FromRoundId = 201201, ToRoundId = 201224},
                new {FirstName = "Mark",    LastName = "Nicoski",   FromRoundId = 201201, ToRoundId = 201224},
                new {FirstName = "Shaun",   LastName = "Grigg",     FromRoundId = 201201, ToRoundId = 201524},
                new {FirstName = "Shaun",   LastName = "Hampson",   FromRoundId = 201201, ToRoundId = 201324},
                new {FirstName = "Cale",    LastName = "Hooker",    FromRoundId = 201101, ToRoundId = 201224},
                new {FirstName = "Luke",    LastName = "Breust",    FromRoundId = 201201, ToRoundId = 201324},
                new {FirstName = "Hamish",  LastName = "Hartlett",  FromRoundId = 200901, ToRoundId = 201224},
                new {FirstName = "Tyrone",  LastName = "Vickery",   FromRoundId = 200901, ToRoundId = 201224},
                new {FirstName = "Aaron",   LastName = "Cornelius", FromRoundId = 201001, ToRoundId = 201224},
                new {FirstName = "Daniel",  LastName = "Menzel",    FromRoundId = 201001, ToRoundId = 201211},
                new {FirstName = "David",   LastName = "Swallow",   FromRoundId = 201101, ToRoundId = 201324},
                new {FirstName = "Max",     LastName = "Gawn",      FromRoundId = 201201, ToRoundId = 201224},
                new {FirstName = "Orren",   LastName = "Stephenson",FromRoundId = 201201, ToRoundId = 201324},
                new {FirstName = "Ahmed",   LastName = "Saad",      FromRoundId = 201201, ToRoundId = 201424}};


            results.ForEach(
                q => _output.WriteLine($"{q.Id} {q.PlayerId} {q.Player.FirstName}, {q.Player.LastName}, {q.FromRoundId}, {q.ToRoundId}"));

            foreach (var player in expectedPlayers)
            {
                _output.WriteLine($"Searching for player {player.FirstName} {player.LastName}");
                Assert.Contains(results, q => q.Player.FirstName == player.FirstName
                    && q.Player.LastName == player.LastName
                    && q.FromRoundId == player.FromRoundId
                    && q.ToRoundId == player.ToRoundId);
                _output.WriteLine($"\tFound player {player.FirstName} {player.LastName}");
            }
        }

        private readonly DdhpContext _ddhpContext = new InMemoryContext();
        private readonly ITestOutputHelper _output;

        protected override void ServicesToRegister(IServiceCollection collection)
        {
            collection.Add(new ServiceDescriptor(typeof(IDdhpContext), _ddhpContext));
        }

        public override void Dispose()
        {
            _ddhpContext.Dispose();
            base.Dispose();
        }
    }
}