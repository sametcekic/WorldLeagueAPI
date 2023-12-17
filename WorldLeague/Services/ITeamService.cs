using WorldLeague.Entities;

namespace WorldLeague.Services;

public interface ITeamService
{
    Task<Team> GetTeamByIdAsync(int id);
     Task<List<Team>> GetAllTeams();
}

 