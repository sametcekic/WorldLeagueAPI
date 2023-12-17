using WorldLeague.Entities;
using WorldLeague.Repository;

namespace WorldLeague.Services;

public class DrawService : IDrawService
{
    private readonly IDrawRepository _drawRepository;
    private readonly ICountryService _countryService;
    private readonly ITeamService _teamService;
    private readonly IGroupService _groupService;

    public DrawService(ITeamService teamService, ICountryService countryService, IDrawRepository drawRepository, IGroupService groupService)
    {
        _teamService = teamService;
        _countryService = countryService;
        _drawRepository = drawRepository;
        _groupService = groupService;
    }

    public async Task<List<Group>> CreateDraw(string drawerName, int groupCount)
    {
        var teams = await _teamService.GetAllTeams();
        var countries = await _countryService.GetAllCountries();
        var groups = await _groupService.GetAllGroups();
 
        List<Group> responseList = new List<Group>();

        int teamsPerGroup = teams.Count / groupCount;

        Random rnd = new Random();
        teams = teams.OrderBy(x => rnd.Next()).ToList();
        countries = countries.OrderBy(x => rnd.Next()).ToList();

        if (groupCount == 8)
        {
            for (int i = 0; i < 4; i++)
            {
                responseList.Add(groups[i]);
                var responseTeams = new List<Team>();
                
                foreach (Country country in countries)
                {
                     var responseTeam = teams.First(i => i.CountryId == country.Id);
                    responseTeams.Add(responseTeam);
                    teams.Remove(responseTeam);
                }
                responseList[i].Teams = responseTeams;
               
            }

        }
        else if (groupCount == 4)
        {
            for (int i = 0; i < 2; i++)
            {
                responseList.Add(groups[i]);
                var responseTeams = new List<Team>();

                foreach (Country country in countries)
                {
                    var responseTeam = teams.First(i => i.CountryId == country.Id);
                    responseTeams.Add(responseTeam);
                    teams.Remove(responseTeam);

                    responseTeam = teams.First(i => i.CountryId == country.Id);
                    responseTeams.Add(responseTeam);
                    teams.Remove(responseTeam);
                }
                responseList[i].Teams = responseTeams;
            }
        }

       await _drawRepository.SaveAsync(new Draw() { DrawerName = drawerName, NumberOfGroups = groupCount, CreatedDate=DateTime.Now });

        
        return responseList;
    }
}
