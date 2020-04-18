namespace DotaESport.Services.Data.Tests.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using DotaESport.Data;
    using DotaESport.Data.Models;

    public class ArticlesTestsSeeder
    {
        public async Task SeedArticleAsync(ApplicationDbContext context, int i)
        {
            var article = new Article
            {
                ImgUrl = $"ImagUrl{i}",
                VideoUrl = string.Empty,
                Content = $"Content{i}",
                Id = i,
                UserId = $"{i}",
                CreatedOn = DateTime.Parse($"2020-04-1{i} 00:00:00.0000000"),
                Comments = new HashSet<Comment>
                    {
                        new Comment
                        {
                            ArticleId = i,
                            CreatedOn = DateTime.Parse($"2020-04-2{i} 00:00:00.0000000"),
                            UserId = $"{i}",
                            Content = $"Content{i}",
                        },
                    },
                Title = $"Title{i}",
                Votes = new HashSet<Vote>
                    {
                        new Vote
                        {
                            ArticleId = i,
                            UserId = $"{i}",
                            Type = VoteType.UpVote,
                        },
                    },
            };
            await context.Articles.AddAsync(article);
            await context.SaveChangesAsync();
        }

    }
}
