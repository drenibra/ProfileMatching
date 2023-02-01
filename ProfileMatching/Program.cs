using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using ProfileMatching.Configurations;
using ProfileMatching.Extensions;
using ProfileMatching.Models;
using ProfileMatching.RecruiterServices;
using ProfileMatching.Services;
using ProfileMatching.ProfileMatchLayer.Users;
using ProfileMatching.ProfileMatchLayer.Applications;
using ProfileMatching.ProfileMatchLayer.Documents;
using ProfileMatching.ProfileMatchLayer.Results;
using ProfileMatching.RecruiterServices.Companies;
using ProfileMatching.RecruiterServices.JobPositions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

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

        builder.Services.AddScoped<ICompany, CompanyService>();
        builder.Services.AddScoped<IJobPosition, JobPositionService>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IApplicationService, ApplicationService>();
        builder.Services.AddScoped<IGetUser, UserService>();
        builder.Services.AddScoped<IDocuments, DocumentService>();
        builder.Services.AddScoped<IResults, ResultService>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddDefaultIdentity<AppUser>().AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();
        builder.Services.AddIdentityServices(builder.Configuration);
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("RequireAdministratorRole",
                 policy => policy.RequireRole("Administrator"));
        });

        var app = builder.Build();

        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

        using (var scope = scopeFactory.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await context.Database.MigrateAsync();
                await Seed.SeedData(context, userManager, roleManager);
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