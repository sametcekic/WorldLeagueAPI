using WorldLeague.Constants;
using WorldLeague.Entities;
using WorldLeague.Repository;

namespace WorldLeague.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public Task<List<Country>> GetAllCountries()
        {
            var countries = _countryRepository.AllAsync();
            return countries;
        }

        public Task<Country> GetCountryByIdAsync(int id)
        {
            var country = _countryRepository.GetByIdAsync(id);
            if (country == null)
            {
                throw new ArgumentException(Messages.CountryDidNotFound);
            }
            else
                return country;
        }
    }
}
