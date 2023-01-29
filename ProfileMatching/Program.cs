using Microsoft.EntityFrameworkCore;
using ProfileMatching.Configurations;
using ProfileMatching.ProfileMatchLayer.Applicants;
using ProfileMatching.ProfileMatchLayer.Applications;
using ProfileMatching.ProfileMatchLayer.Documents;
using ProfileMatching.ProfileMatchLayer.Results;
using ProfileMatching.RecruiterServices.Companies;
using ProfileMatching.RecruiterServices.JobPositions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICompany, CompanyService>();
builder.Services.AddScoped<IJobPosition, JobPositionService>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IDocuments, DocumentService>();
builder.Services.AddScoped<IResults, ResultService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
