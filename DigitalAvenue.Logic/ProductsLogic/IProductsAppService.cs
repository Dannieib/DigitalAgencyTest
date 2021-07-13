using DigitalAvenue.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DigitalAvenue.Logic.ProductsLogic
{
    public interface IProductsAppService
    {
        Task<SalesModel> DeleteSalesById(int id);
        Task<IEnumerable<ProductModel>> getAllProducts();
        Task<PagedListModel<SalesModel>> getSalesByFiltering(string Search = null, DateTime? dateFrom = null, DateTime? dateTo = null, int StartIndex = 0, int Count = int.MaxValue);
        Task<SalesModel> GetSalesById(int id);
        Task<int> InsertNewSales(SalesModel model);
        Task<SalesModel> UpdateSalesById(SalesModel model);
    }
}