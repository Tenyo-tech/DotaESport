using System;
using Microsoft.EntityFrameworkCore;

namespace DotaESport.Services.Data.Tests
{
    using DotaESport.Data;
    using DotaESport.Data.Models;
    using DotaESport.Data.Repositories;
    using System.Threading.Tasks;
    using Xunit;

    public class VotesServiceTests
    {
        [Fact]
        public async Task TwoDownVotesShouldCountOnce()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Give a Unique name to the DB
                .Options;

            var repository = new EfRepository<Vote>(new ApplicationDbContext(options));

            var service = new VotesService(repository);

            for (int i = 0; i < 100; i++)
            {
                await service.VoteAsync(1, "1", false);
            }

            for (int i = 0; i < 100; i++)
            {
                await service.VoteAsync(1, "2", false);
            }

            var votes = service.GetVotes(1);
            Assert.Equal(-2, votes);
        }
    }
}
