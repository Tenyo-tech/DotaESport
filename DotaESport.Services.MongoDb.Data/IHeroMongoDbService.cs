using DotaESport.MongoDb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaESport.Services.MongoDb.Data
{
    public interface IHeroMongoDbService
    {
        void GetAllHeroes();
    }
}
