using Microsoft.EntityFrameworkCore;
using WorldLeague.Entities;
using WorldLeague.Repository;

namespace WorldLeagueAPI.Repository;

public class TeamRepository : GenericRepository<Team>, ITeamRepository
{
    public TeamRepository(ApplicationDbContext context) : base(context)
    {
    }
}