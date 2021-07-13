using DigitalAvenue.Models.LocationModels;
using DigitalAvenue.Repository.LocationsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAvenue.Logic.LocationLogic
{
    public class LocationAppService : ILocationAppService
    {
        private readonly ILocationRepo _locationRepo;
        public LocationAppService(ILocationRepo locationRepo)
        {
            _locationRepo = locationRepo;
        }

        public async Task<IEnumerable<CountryModel>> GetAllCountries()
        {
            try
            {
                return await _locationRepo.GetAllCountries();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<RegionModel>> GetAllRegionByCountryCode(char countryCode)
        {
            try
            {
                return await _locationRepo.GetAllRegionByCountryCode(countryCode);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<IEnumerable<CityModel>> GetAllCitiesByRegionCode(char regionCode)
        {
            try
            {
                return await _locationRepo.GetAllCitiesByRegionCode(regionCode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
