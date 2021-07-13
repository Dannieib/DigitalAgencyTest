using DigitalAvenue.Models.LocationModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalAvenue.Repository.LocationsRepo
{
    public interface ILocationRepo
    {
        Task<IEnumerable<CityModel>> GetAllCitiesByRegionCode(char regionCode);
        Task<IEnumerable<CountryModel>> GetAllCountries();
        Task<IEnumerable<RegionModel>> GetAllRegionByCountryCode(char countryCode);
    }
}