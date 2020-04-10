using Microsoft.AspNetCore.Authorization;

namespace DotaESport.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DotaESport.Data.Models;
    using Microsoft.AspNetCore.SignalR;

    [Authorize]
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync(
                "NewMessage",
                new Message
                {
                    User = this.Context.User.Identity.Name, 
                    Text = message,
                });
        }
    }

}
