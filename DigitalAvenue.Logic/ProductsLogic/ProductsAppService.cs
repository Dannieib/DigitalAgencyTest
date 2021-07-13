using DigitalAvenue.Logic.LocationLogic;
using DigitalAvenue.Models;
using DigitalAvenue.Repository.ProductsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalAvenue.Logic.ProductsLogic
{
    public class ProductsAppService : IProductsAppService
    {
        private readonly IProductRepo _productRepo;
        readonly ILocationAppService _locationAppService;

        public ProductsAppService(IProductRepo productRepo, ILocationAppService locationAppService)
        {
            _productRepo = productRepo;
            _locationAppService = locationAppService;
        }

        public async Task<IEnumerable<ProductModel>> getAllProducts()
        {
            try
            {
                return await _productRepo.getAllProducts();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PagedListModel<SalesModel>> getSalesByFiltering(string Search = null, DateTime? dateFrom = null,
            DateTime? dateTo = null, int StartIndex = 0, int Count = int.MaxValue)
        {
            try
            {
                return await _productRepo.getSalesByFiltering(Search, dateFrom, dateTo, StartIndex, Count);
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
                return await _productRepo.InsertNewSales(model);
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
                return model.Id > 0 ? await _productRepo.UpdateSalesById(model) : new SalesModel();
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
                return id > 0 ? await _productRepo.GetSalesById(id) : null;
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
                return id > 0 ? await _productRepo.DeleteSalesById(id) : null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
