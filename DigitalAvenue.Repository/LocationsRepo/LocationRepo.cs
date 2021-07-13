using Dapper;
using DigitalAvenue.Models.LocationModels;
using DigitalAvenue.Repository.StorageUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAvenue.Repository.LocationsRepo
{
    public class LocationRepo : ILocationRepo
    {
        private readonly IStorage _storage;

        public LocationRepo(IStorage storage)
        {
            _storage = storage;
        }

        public async Task<IEnumerable<CountryModel>> GetAllCountries()
        {
            try
            {
                using (IDbConnection conn = _storage.Connection)
                {
                    var sql = $"dbo.spGetAllCountries";
                    var result = await conn.QueryAsync<CountryModel>(sql);
                    return result;
                }
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
                using (IDbConnection conn = _storage.Connection)
                {
                    var sql = $"[dbo].[spGetRegionByCountryCode] @countryCode";
                    var result = await conn.QueryAsync<RegionModel>(sql, new
                    {
                        countryCode
                    });
                    return result;
                }
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
                using (IDbConnection conn = _storage.Connection)
                {
                    var sql = $"[dbo].[spGetAllCities] @regionCode";
                    var result = await conn.QueryAsync<CityModel>(sql, new
                    {
                        regionCode
                    });
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
