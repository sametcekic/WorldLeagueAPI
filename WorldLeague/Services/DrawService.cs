using WorldLeague.Entities;
using WorldLeague.Repository;

namespace WorldLeague.Services;

public class DrawService : IDrawService
{
    private readonly IDrawRepository _drawRepository;
    private readonly ICountryService _countryService;
    private readonly ITeamService _teamService;

    public DrawService( ITeamService teamService, ICountryService countryService, IDrawRepository drawRepository)
    {
        _teamService = teamService;
        _countryService = countryService;
        _drawRepository = drawRepository;
    }

    public async Task<List<Group>> CreateDraw(string drawerName, int groupCount)
    {
        var teams = await _teamService.GetAllTeams();
        var countries = await _countryService.GetAllCountries();

        List<Group> responseList = new List<Group>();

        int teamsPerGroup = teams.Count / groupCount;

        Random rnd = new Random();
        teams = teams.OrderBy(x => rnd.Next()).ToList();
        countries = countries.OrderBy(x => rnd.Next()).ToList();

        if (groupCount == 8)
        {
            for (int i = 0; i < groupCount; i++)
            {
                foreach (Country country in countries)
                {
                    responseList[i].Teams.Add(teams.First(i => i.CountryId == country.Id));
                    teams.Remove(teams.First());
                }
            }

        }
        else if (groupCount == 4)
        {
            for (int i = 0; i < groupCount; i++)
            {
                foreach (Country country in countries)
                {
                    responseList[i].Teams.Add(teams.First(i => i.CountryId == country.Id));

                    teams.Remove(teams.First());

                    responseList[i].Teams.Add(teams.First(i => i.CountryId == country.Id));

                    teams.Remove(teams.First());
                }
            }
        }

        _drawRepository.SaveAsync(new Draw() { DrawerName = drawerName, NumberOfGroups = groupCount });
        return responseList;
    }
}
