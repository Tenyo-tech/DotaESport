using System;
using System.Collections.Generic;
using System.Text;

namespace DotaESport.MongoDb.Data
{
    public interface IDotaESportDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
