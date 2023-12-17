using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;
using WorldLeague.Entities;
using WorldLeague.Repository.Mappers;

namespace WorldLeague.Repository;

public class ApplicationDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<Country> Country { get; set; }
    public DbSet<Team> Team { get; set; }
    public DbSet<Draw> Draw { get; set; }
    public DbSet<Group> Group { get; set; }
    public ApplicationDbContext()
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { 
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();


        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("dbConnectionString not found!!");
        }
        optionsBuilder.UseSqlServer(connectionString);
    }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new CountryMapper().BaseMap(modelBuilder);
        new TeamMapper().BaseMap(modelBuilder);
        new GroupMapper().BaseMap(modelBuilder);
        new DrawMapper().BaseMap(modelBuilder);
        base.OnModelCreating(modelBuilder);
     }
}
