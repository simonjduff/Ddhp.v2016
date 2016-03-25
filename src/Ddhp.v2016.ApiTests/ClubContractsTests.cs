using System;
using System.Linq;
using Ddhp.v2016.ApiTests.DataSources;
using Ddhp.v2016.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Ddhp.v2016.ApiTests
{
    [Collection("InMemory")]
    public class ClubContractsTests : InMemoryTestsBase
    {
        public ClubContractsTests()
        {
            var player1 = new Player { FirstName = "First1", LastName = "Second1" };
            _ddhpContext.Players.Add(player1);
            var player2 = new Player { FirstName = "First2", LastName = "Second2" };
            _ddhpContext.Players.Add(player2);

            _ddhpContext.Stats.Add(new Stat { Player = player1 });
            _ddhpContext.Stats.Add(new Stat { Player = player2 });
            _ddhpContext.Stats.Add(new Stat { Player = player2 });

            _ddhpContext.SaveChanges();
        }

        [Fact]
        public void AveragesAreCorrect()
        {
            Assert.Equal(3, _ddhpContext.Stats.Count());
            Assert.Equal(12, _ddhpContext.DdhpClubs.Count());
        }

        private readonly DdhpContext _ddhpContext = new InMemoryContext();

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