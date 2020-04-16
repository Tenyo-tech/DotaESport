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
        public async Task TestVoteAsyncMethod()
        {
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var votesRepository = new EfRepository<Vote>(context);

            var service = new VotesService(votesRepository);

            await service.VoteAsync(5, "e6335b0d-322e-48c8-9d42-205d3915ed39", true);
            var votes = service.GetVotes(5);
            Assert.Equal(1, votes);

        }

        [Fact]
        public async Task TestGetVotesMethod()
        {
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var votesRepository = new EfRepository<Vote>(context);

            var service = new VotesService(votesRepository);

            for (int i = 0; i < 100; i++)
            {
                await service.VoteAsync(5, $"{i}", true);
            }

            var votes = service.GetVotes(5);

            Assert.Equal(100, votes);
        }

        [Fact]
        public async Task TwoDownVotesShouldCountOnce()
        {
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var votesRepository = new EfRepository<Vote>(context);

            var service = new VotesService(votesRepository);

            for (int i = 0; i < 100; i++)
            {
                await service.VoteAsync(5, "e6335b0d-322e-48c8-9d42-205d3915ed39", false);
            }

            for (int i = 0; i < 100; i++)
            {
                await service.VoteAsync(5, "d4b831df-ef23-4127-883a-76cd2533e28a", false);
            }

            var votes = service.GetVotes(5);

            Assert.Equal(-2, votes);
        }
    }
}
