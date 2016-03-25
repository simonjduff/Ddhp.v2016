using System.IO;
using Ddhp.v2016.Models;
using Ddhp.v2016.Models.Ddhp;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Newtonsoft.Json;

namespace Ddhp.v2016.ApiTests.DataSources
{
    public sealed class InMemoryContext : DdhpContext
    {
        public static bool DataImported;

        public InMemoryContext() : base(Options)
        {
            if (DataImported)
            {
                return;
            }

            var clubs = JsonConvert.DeserializeObject<Club[]>(File.ReadAllText(@"Data\clubs.json"));
            DdhpClubs.AddRange(clubs);
            SaveChanges();

            DataImported = true;
        }

        private static DbContextOptions Options
        {
            get
            {
                var optionsBuilder = new DbContextOptionsBuilder<DdhpContext>();
                optionsBuilder.UseInMemoryDatabase();
                return optionsBuilder.Options;
            }
        }

        private bool _isDisposed;

        public override void Dispose()
        {
            // We have the isDisposed check here as base.Dispose seems to loop back and call this Dispose a second time
            if (!_isDisposed) { Database.EnsureDeleted();}
            _isDisposed = true;
            base.Dispose();
        }
    }
}