using DigitalAvenue.Models.LocationModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalAvenue.Logic.LocationLogic
{
    public interface ILocationAppService
    {
        Task<IEnumerable<CityModel>> GetAllCitiesByRegionCode(char regionCode);
        Task<IEnumerable<CountryModel>> GetAllCountries();
        Task<IEnumerable<RegionModel>> GetAllRegionByCountryCode(char countryCode);
    }
}