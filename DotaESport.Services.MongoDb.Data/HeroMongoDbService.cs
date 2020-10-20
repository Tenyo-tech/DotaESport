using DotaESport.MongoDb.Data;
using MongoDB.Driver;
using OpenDotaDotNet;
using OpenDotaDotNet.Models.Heroes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotaESport.Services.MongoDb.Data
{
    public class HeroMongoDbService
    {
        private readonly IMongoCollection<Hero> heroesRepository;

        public HeroMongoDbService(IDotaESportDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            ;
            heroesRepository = database.GetCollection<Hero>("Heroes");
        }
        public IEnumerable<Hero> GetAllHeroes()
        {
            var openDota = new OpenDotaApi();

            var heroes = openDota.Heroes.GetHeroesAsync().Result;

            return heroes;
        }
    }
}
