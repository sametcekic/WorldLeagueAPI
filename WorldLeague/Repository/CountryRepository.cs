using Microsoft.EntityFrameworkCore;
using WorldLeague.Entities;
using WorldLeague.Repository;

namespace WorldLeagueAPI.Repository;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    public CountryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
