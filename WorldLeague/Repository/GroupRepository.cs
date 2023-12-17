using Microsoft.EntityFrameworkCore;
using WorldLeague.Entities;
using WorldLeague.Repository;

namespace WorldLeagueAPI.Repository;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    public GroupRepository(ApplicationDbContext context) : base(context)
    {
    }
}