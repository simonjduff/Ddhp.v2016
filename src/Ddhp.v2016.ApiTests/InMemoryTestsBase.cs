using System;
using System.IO;
using System.Linq;
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
        private static bool _testDataRun;
        private static readonly object Lock = new object();

        protected DdhpContext DdhpContext
        {
            get
            {
                if (!_testDataRun)
                {
                    lock (Lock)
                    {
                        if (!_testDataRun)
                        {
                            GivenTheTestData();
                            _testDataRun = true;
                        }
                    }
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
                .UseServices(q => q.Add(new ServiceDescriptor(typeof(IDdhpContext), _ddhpContext)));
            var server = new TestServer(webHostBuilder);
            Client = server.CreateClient();
        }

        public void Dispose()
        {
            DdhpContext.Database.EnsureDeleted();
        }

        public virtual void GivenTheTestData()
        {
            if (_ddhpContext.DdhpClubs.Any()) { throw new ApplicationException("It's all gone wrong");}

            var clubs = JsonConvert.DeserializeObject<Club[]>(File.ReadAllText(@"Data\clubs.json"));
            _ddhpContext.DdhpClubs.AddRange(clubs);
            _ddhpContext.SaveChanges();
        }
    }
}