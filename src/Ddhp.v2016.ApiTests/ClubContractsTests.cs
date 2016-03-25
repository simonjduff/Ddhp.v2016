using System.Linq;
using Ddhp.v2016.ApiTests.DataSources;
using Ddhp.v2016.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Ddhp.v2016.ApiTests
{
 public class ClubContractsTests : InMemoryTestsBase
    {
        [Fact]
        public void AveragesAreCorrect()
        {
            
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