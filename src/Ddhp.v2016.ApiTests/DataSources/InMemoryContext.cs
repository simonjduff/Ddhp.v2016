using System.IO;
using System.Threading.Tasks;
using Ddhp.v2016.Models;
using Ddhp.v2016.Models.Ddhp;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Newtonsoft.Json;

namespace Ddhp.v2016.ApiTests.DataSources
{
    public sealed class InMemoryContext : DdhpContext
    {
        static InMemoryContext()
        {
            var context = new DdhpContext(DbContextOptions);

            SetupData(context);
        }

        private static DbContextOptions<DdhpContext> DbContextOptions
        {
            get
            {
                var optionsBuilder = new DbContextOptionsBuilder<DdhpContext>();
                optionsBuilder.UseInMemoryDatabase();

                var dbContextOptions = optionsBuilder.Options;
                return dbContextOptions;
            }
        }

        public InMemoryContext() : base(DbContextOptions)
        {
            
        }

        private static void SetupData(DdhpContext context)
        {
                var clubs = Task.Run(() => JsonConvert.DeserializeObject<Club[]>(File.ReadAllText(@"Data\clubs.json")));
                var players = Task.Run(() => JsonConvert.DeserializeObject<Player[]>(File.ReadAllText(@"Data\players.json")));
                var stats = Task.Run(() => JsonConvert.DeserializeObject<Stat[]>(File.ReadAllText(@"Data\stats.json")));
                var contracts = Task.Run(() => JsonConvert.DeserializeObject<Contract[]>(File.ReadAllText(@"Data\contracts.json")));
                var rounds = Task.Run(() => JsonConvert.DeserializeObject<Round[]>(File.ReadAllText(@"Data/rounds.json")));

                context.DdhpClubs.AddRange(clubs.Result);
                context.Players.AddRange(players.Result);
                context.Contracts.AddRange(contracts.Result);
                context.Stats.AddRange(stats.Result);
                context.Rounds.AddRange(rounds.Result);

                context.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // The test data files contain Id values already, so we'll use those rather than
            // generated Identity values.
            modelBuilder.Entity<Contract>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<Player>().Property(e => e.Id).ValueGeneratedNever();
            modelBuilder.Entity<Club>().Property(e => e.Id).ValueGeneratedNever();
        }
    }
}