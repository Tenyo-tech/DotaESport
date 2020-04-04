using System.Threading.Tasks;
using DotaESport.Data.Models;
using DotaESport.Web.ViewModels.Votes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DotaESport.Web.Controllers
{
    using DotaESport.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class VotesController : ControllerBase
    {
        private readonly IVotesServices votesServices;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(IVotesServices votesServices, UserManager<ApplicationUser> userManager)
        {
            this.votesServices = votesServices;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<VoteResponseModel>> Article(VoteInputModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.votesServices.VoteAsync(input.ArticleId, userId, input.IsUpVote);
            var votes = this.votesServices.GetVotes(input.ArticleId);
            return new VoteResponseModel { VotesCount = votes };
        }
    }
}
