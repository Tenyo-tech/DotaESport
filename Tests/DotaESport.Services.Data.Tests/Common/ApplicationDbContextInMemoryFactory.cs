using System;
using System.Collections.Generic;
using System.Text;
using DotaESport.Data;
using Microsoft.EntityFrameworkCore;

namespace DotaESport.Services.Data.Tests
{
    public class ApplicationDbContextInMemoryFactory
    {
        public static ApplicationDbContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
