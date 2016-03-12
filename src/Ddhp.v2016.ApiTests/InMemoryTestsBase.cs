using System;
using System.Net.Http;
using Ddhp.v2016.Models;
using Microsoft.AspNet.TestHost;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace Ddhp.v2016.ApiTests
{
    public class InMemoryTestsBase : IDisposable
    {
        protected readonly DdhpContext DdhpContext;
        protected readonly HttpClient Client;

        public InMemoryTestsBase()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DdhpContext>();
            optionsBuilder.UseInMemoryDatabase();
            DdhpContext = new DdhpContext(optionsBuilder.Options);

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
    }
}