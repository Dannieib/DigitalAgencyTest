using Dapper;
using DigitalAvenue.Models;
using DigitalAvenue.Repository.StorageUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAvenue.Repository.ProductsRepo
{
    public class ProductRepo : IProductRepo
    {
        private readonly IStorage _storage;
        public IEnumerable<SalesModel> _InMemorySales {get;set;}

        public ProductRepo(IStorage storage)
        {
            _storage = storage;
        }

        public async Task<IEnumerable<ProductModel>> getAllProducts()
        {
            try
            {
                using (var con = _storage.Connection)
                {
                    var sql = $"[dbo].[spGetAllProduct]";
                    var result = await con.QueryAsync<ProductModel>(sql);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region sale data starts here...........................................

        public async Task<PagedListModel<SalesModel>> getSalesByFiltering(string Search = null, DateTime? dateFrom = null,
            DateTime? dateTo = null, int StartIndex = 0, int Count = int.MaxValue)
        {
            try
            {
                using (var con = _storage.Connection)
                {
                    var sql = $"[dbo].[spFilterSalesinformation] @dateFrom, @dateTo, @Search," +
                        $" @StartIndex, @Count";
                    var result = await con.QueryAsync<SalesModel>(sql, new
                    {
                        dateFrom,
                        dateTo,
                        Search,
                        StartIndex, 
                        Count
                    });

                    var pagedList = new PagedListModel<SalesModel>
                    {
                        List = result.ToList(),
                        FilteredCount = result.Skip(StartIndex).Take(Count).Count(),
                        TotalCount = result.Count()
                    };
                    return pagedList;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> InsertNewSales(SalesModel model)
        {
            try
            {
                using (var con = _storage.Connection)
                {
                    var sql = $"[dbo].[spInsertNewSales] @customerName,@country,@region,@city,@productId,@quantity";
                    var result = await con.ExecuteScalarAsync<int>(sql, new
                    {
                        model.CustomerName,
                        model.Country,
                        model.Region,
                        model.City,
                        model.productId,
                        model.Quantity
                    });

                    if (result>0)
                    {
                        return result;
                    }
                    // log here to db that nothing was saved/inserted to the database.
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SalesModel> UpdateSalesById(SalesModel model)
        {
            try
            {
                using (var con = _storage.Connection)
                {
                    var sql = $"[dbo].[spUpdateSaleInfo] @id,@customerName,@country,@region,@city,@productId,@quantity";
                    var result = await con.ExecuteScalarAsync<SalesModel>(sql, new
                    {
                        model.Id,
                        model.CustomerName,
                        model.Country,
                        model.Region,
                        model.City,
                        model.productId,
                        model.Quantity
                    });

                    if (result!=null)
                    {
                        return result;
                    }
                    // log here to db that nothing was updated on the database.
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SalesModel> GetSalesById(int id)
        {
            try
            {
                using (var con = _storage.Connection)
                {
                    var sql = $"[dbo].[spGetSalesBySalesId] @id";
                    var result = await con.QueryFirstOrDefaultAsync<SalesModel>(sql, new
                    {
                       id
                    });
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SalesModel> DeleteSalesById(int id)
        {
            try
            {
                using (var con = _storage.Connection)
                {
                    var sql = $"[dbo].[spDeleteSaleById] @id";
                    var result = await con.ExecuteScalarAsync<SalesModel>(sql, new
                    {
                        id
                    });
                    if (result !=null)
                    {
                        return result;
                    }
                    // log here to db that nothing was deleted from the database.
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
