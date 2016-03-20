using System;
using System.IO;
using System.Net.Http;
using Ddhp.v2016.Models;
using Ddhp.v2016.Models.Ddhp;
using Microsoft.AspNet.TestHost;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Ddhp.v2016.ApiTests
{
    public class InMemoryTestsBase : IDisposable
    {
        private readonly DdhpContext _ddhpContext;
        protected readonly HttpClient Client;
        private bool _testDataRun;

        protected DdhpContext DdhpContext
        {
            get
            {
                if (!_testDataRun)
                {
                    GivenTheTestData();
                    _testDataRun = true;
                }

                return _ddhpContext;
            }
        }

        public InMemoryTestsBase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DdhpContext>();
            optionsBuilder.UseInMemoryDatabase();
            _ddhpContext = new DdhpContext(optionsBuilder.Options);

            var webHostBuilder = TestServer.CreateBuilder()
                .UseStartup<Startup>()
                .UseServices(q => q.Add(new ServiceDescriptor(typeof(IDdhpContext), DdhpContext)));
            var server = new TestServer(webHostBuilder);
            Client = server.CreateClient();
        }

        public void Dispose()
        {
            DdhpContext.Database.EnsureDeleted();
        }

        public virtual void GivenTheTestData()
        {
            var clubs = JsonConvert.DeserializeObject<Club[]>(File.ReadAllText(@"Data\clubs.json"));
            DdhpContext.DdhpClubs.AddRange(clubs);
            DdhpContext.SaveChanges();
        }
    }
}