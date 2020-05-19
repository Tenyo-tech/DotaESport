using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaESport.Common;
using DotaESport.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace DotaESport.Data.Seeding
{
    public class AddRoleToUserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var role = await roleManager.FindByNameAsync(GlobalConstants.AdminRoleName);

            var user = await userManager.FindByNameAsync(GlobalConstants.TenyoUserName);

            //var exist = dbContext.UserRoles.Any(x => x.UserId == user.Id &&
            //                                         x.RoleId == role.Id);
            //;
            //if (exist)
            //{
            //    return;
            //}

            //await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            //{
            //    RoleId = role.Id,
            //    UserId = user.Id,
            //});

            //await dbContext.SaveChangesAsync();
        }
    }
}
