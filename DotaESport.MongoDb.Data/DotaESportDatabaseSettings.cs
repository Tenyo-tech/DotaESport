using System;
using System.Collections.Generic;
using System.Text;

namespace DotaESport.MongoDb.Data
{
    public class DotaESportDatabaseSettings : IDotaESportDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
