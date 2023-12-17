using Microsoft.EntityFrameworkCore;
using WorldLeague.Repository;
using WorldLeague.Services;
using WorldLeagueAPI.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IDrawRepository, DrawRepository>();
builder.Services.AddTransient<ITeamRepository, TeamRepository>();
builder.Services.AddTransient<IGroupRepository, GroupRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();

builder.Services.AddTransient<ITeamService, TeamService>();
builder.Services.AddTransient<IGroupService, GroupService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<IDrawService, DrawService>();

builder.Services.AddControllers();

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
