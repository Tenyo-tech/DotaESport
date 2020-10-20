namespace DotaESport.Web
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AspNet.Security.OpenId.Steam;
    using DotaESport.Data;
    using DotaESport.Data.Common;
    using DotaESport.Data.Common.Repositories;
    using DotaESport.Data.Models;
    using DotaESport.Data.Repositories;
    using DotaESport.Data.Seeding;
    using DotaESport.MongoDb.Data;
    using DotaESport.Services.Data;
    using DotaESport.Services.Mapping;
    using DotaESport.Services.Messaging;
    using DotaESport.Services.MongoDb.Data;
    using DotaESport.Web.Hubs;
    using DotaESport.Web.ViewModels;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.
                AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddAuthentication(options =>
                {
                    /* Authentication options */
                }).AddSteam(steamoptions =>
                {
                    steamoptions.ApplicationKey = "B82E78CDDACE931ADF354E26542D0E5B";
                });

            //.AddFacebook(facebookOptions =>
            // {
            //     facebookOptions.AppId = this.configuration["Authentication:Facebook:AppId"];
            //     facebookOptions.AppSecret = this.configuration["Authentication:Facebook:AppSecret"];
            // })

            services.Configure<DotaESportDatabaseSettings>(
       this.configuration.GetSection(nameof(DotaESportDatabaseSettings)));

            services.AddSingleton<IDotaESportDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DotaESportDatabaseSettings>>().Value);

            services.AddSingleton<HeroMongoDbService>();

            services.AddControllersWithViews(options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                });

            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";

            });


            services.AddSignalR();

            services.AddRazorPages();

            services.AddSingleton(this.configuration);


            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();

            services.AddTransient<ISettingsService, SettingsService>();

            services.AddTransient<IHeroService, HeroService>();
            services.AddTransient<IArticlesService, ArticlesService>();
            services.AddTransient<IVotesServices, VotesService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IItemsService, ItemsService>();
            services.AddTransient<IRecipesService, RecipesService>();
            services.AddTransient<ISkillsService, SkillsService>();
            services.AddTransient<ITeamsServices, TeamService>();
            services.AddTransient<IPlayersService, PlayersService>();
            services.AddTransient<ITournamentsService, TournamentsService>();
            services.AddTransient<IGameplayUpdatesService, GameplayUpdatesService>();
            services.AddTransient<ISteamInfoService, SteamInfoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (env.IsDevelopment())
                {
                    dbContext.Database.Migrate();
                }

                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }



            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("/Home/HttpError?statusCode={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

                        endpoints.MapRazorPages();
                        endpoints.MapHub<ChatHub>("/Chat");
                    });
        }
    }
}
