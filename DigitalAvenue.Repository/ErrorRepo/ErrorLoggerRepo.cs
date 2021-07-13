using Dapper;
using DigitalAvenue.Models;
using DigitalAvenue.Repository.StorageUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAvenue.Repository.ErrorRepo
{
    public class ErrorLoggerRepo : IErrorLoggerRepo
    {
        private readonly IStorage _storage;
        public ErrorLoggerRepo(IStorage storage)
        {
            _storage = storage;
        }

        public async Task<int> LognewError(ErrorLogModel model)
        {
            try
            {
                var conn = _storage.Connection;
                var sql = $"[dbo].[spLogErrorToDB] @errorMessage, @errorStackTrace, @ErrorType";
                var res = await conn.ExecuteScalarAsync<int>(sql, new
                {
                    model.ErrorMessage,
                    model.ErrorStackTrace,
                    model.ErrorType
                });

                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
