using Microsoft.EntityFrameworkCore;
using WorldLeague.Repository;
using WorldLeague.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDrawService, DrawService>();
builder.Services.AddScoped<ITeamService, TeamService>();
builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<ICountryService, CountryService>();

var app = builder.Build();
builder.Services.AddDbContext<DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



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
