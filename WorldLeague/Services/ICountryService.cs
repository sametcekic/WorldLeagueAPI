using WorldLeague.Entities;

namespace WorldLeague.Services;

public interface ICountryService
{
    Task<Country> GetCountryByIdAsync(int id);
     Task<List<Country>> GetAllCountries();
}

 