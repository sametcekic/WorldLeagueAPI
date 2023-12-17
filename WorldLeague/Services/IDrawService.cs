using WorldLeague.Entities;

namespace WorldLeague.Services;

public interface IDrawService
{
    Task<List<Group>> CreateDraw(string drawerName, int countryCount);
}

 