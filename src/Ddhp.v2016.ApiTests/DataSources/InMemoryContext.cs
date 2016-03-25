﻿using System.IO;
using System.Threading.Tasks;
using Ddhp.v2016.Models;
using Ddhp.v2016.Models.Ddhp;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Newtonsoft.Json;

namespace Ddhp.v2016.ApiTests.DataSources
{
    public sealed class InMemoryContext : DdhpContext
    {
        public static bool DataImported;
        private static readonly object ThreadLock = new object();

        public InMemoryContext() : base(Options)
        {
            SetupData(this);
        }

        private static void SetupData(DdhpContext context)
        {
            lock (ThreadLock)
            {
                if (DataImported)
                {
                    return;
                }

                var clubs = Task.Run(() => JsonConvert.DeserializeObject<Club[]>(File.ReadAllText(@"Data\clubs.json")));
                var players = Task.Run(() => JsonConvert.DeserializeObject<Player[]>(File.ReadAllText(@"Data\players.json")));
                var stats = Task.Run(() => JsonConvert.DeserializeObject<Stat[]>(File.ReadAllText(@"Data\stats.json")));

                context.DdhpClubs.AddRange(clubs.Result);
                context.Players.AddRange(players.Result);
                context.Stats.AddRange(stats.Result);

                context.SaveChanges();

                DataImported = true;
            }
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
    }
}