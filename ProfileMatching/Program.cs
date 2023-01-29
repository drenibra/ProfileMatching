using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using ProfileMatching.Configurations;
using ProfileMatching.Extensions;
using ProfileMatching.Models;
using ProfileMatching.RecruiterServices;
using ProfileMatching.RecruiterServices.Interfaces;
using ProfileMatching.Services;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers(opt =>
        {
            // Cdo Endpoint kerkon authentication, pervec atyre qe ia shtojme [AllowAnonnymous]
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            opt.Filters.Add(new AuthorizeFilter(policy));
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllersWithViews();
        builder.Services.AddIdentityServices(builder.Configuration);
        builder.Services.AddScoped<ICompany, CompanyService>();
        builder.Services.AddScoped<IJobPosition, JobPositionService>();
        //var userManager = builder.Services.GetRequiredService<UserManager<AppUser>>();

        var app = builder.Build();
        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

        using (var scope = scopeFactory.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                await context.Database.MigrateAsync();
                await Seed.SeedData(context, userManager);
            } catch(Exception ex) {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            }
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();


        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        await app.RunAsync();
    }
}