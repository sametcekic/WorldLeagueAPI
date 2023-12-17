using WorldLeague.Constants;
using WorldLeague.Entities;
using WorldLeague.Repository;

namespace WorldLeague.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public Task<List<Team>> GetAllTeams()
        {
            var teams = _teamRepository.AllAsync();
            return teams;
        }
  
        public Task<Team> GetTeamByIdAsync(int id)
        {
            var team = _teamRepository.GetByIdAsync(id);
            if (team == null)
            {
                throw new ArgumentException(Messages.TeamDidNotFound);
            }
            else
                return team;
        }
    }
}
