using Microsoft.EntityFrameworkCore;
using WorldLeague.Entities;
using WorldLeague.Repository;

namespace WorldLeagueAPI.Repository;

public class DrawRepository : GenericRepository<Draw>, IDrawRepository
{
    public DrawRepository(ApplicationDbContext context) : base(context)
    {
    }
}