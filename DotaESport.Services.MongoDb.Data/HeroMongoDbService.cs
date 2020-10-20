using DotaESport.MongoDb.Data;
using DotaESport.MongoDb.Data.Models;
using MongoDB.Driver;
using OpenDotaDotNet;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaESport.Services.MongoDb.Data
{
    public class HeroMongoDbService : IHeroMongoDbService
    {
        private readonly IMongoCollection<Hero> heroesRepository;

        public HeroMongoDbService(IDotaESportDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            heroesRepository = database.GetCollection<Hero>("Heroes");
        }
        public void GetAllHeroes()
        {
            var openDota = new OpenDotaApi();

            var heroes = openDota.Heroes;
            ;
            return ;
        }
    }
}
