using DigitalAvenue.Logic;
using DigitalAvenue.Logic.LocationLogic;
using DigitalAvenue.Logic.ProductsLogic;
using DigitalAvenue.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DigitalAvenue.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        readonly IProductsAppService _productAppService;
        readonly ILocationAppService _locationAppService;
        readonly IErrorServiceHandler _errorServiceHandler;

        public SalesController(IProductsAppService productsAppService, ILocationAppService locationAppService, IErrorServiceHandler errorServiceHandler)
        {
            _locationAppService = locationAppService;
            _productAppService = productsAppService;
            _errorServiceHandler = errorServiceHandler;
        }

        [HttpPost("addnew")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddNewSale(SalesModel model)
        {
            try
            {
                if (!ModelState.IsValid && model == null)
                    throw new ArgumentNullException("Parameter cannot be validated");

                var response = await _productAppService.InsertNewSales(model);
                if (response>0)
                    return Ok(response);

                await _errorServiceHandler.Save("Update info for sales returned null", null, ErrorTypeEnum.NormalError);
                return BadRequest(null);
            }
            catch (Exception ex)
            {
                await _errorServiceHandler.Save(ex.Message, ex.StackTrace, ErrorTypeEnum.Exception);
                throw;
            }
        }

        [HttpPost("updateinfo")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SalesModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateSale(SalesModel model)
        {
            try
            {
                if (!ModelState.IsValid && model == null)
                    throw new ArgumentNullException("Parameter cannot be validated");

                var response = await _productAppService.UpdateSalesById(model);
                if (response!=null)
                    return Ok(response);

                await _errorServiceHandler.Save("Update info for sales returned null", null, ErrorTypeEnum.NormalError);
                return BadRequest(null);
            }
            catch (Exception ex)
            {
                await _errorServiceHandler.Save(ex.Message, ex.StackTrace, ErrorTypeEnum.Exception);
                throw;
            }
        }

        [HttpPost("deleteinfo")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SalesModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteSaleInfo(int id)
        {
            try
            {
                if (!ModelState.IsValid && id == 0)
                    throw new ArgumentNullException("No parameter passed.");

                var response = await _productAppService.DeleteSalesById(id);
                if (response != null)
                    return Ok(response);

                await _errorServiceHandler.Save("delete info returned null for sales", null, ErrorTypeEnum.NormalError);
                return BadRequest(null);
            }
            catch (Exception ex)
            {
                await _errorServiceHandler.Save(ex.Message, ex.StackTrace, ErrorTypeEnum.Exception);
                throw;
            }
        }

        [HttpPost("filterInfo")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PagedListModel<SalesModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> FilterSaleInfo(string search=null,DateTime? dateFrom=null, DateTime? dateTo = null, int skip=0, int take=int.MaxValue)
        {
            try
            {

                return Ok(await _productAppService.getSalesByFiltering(Search:search, dateFrom:dateFrom, dateTo:dateTo, StartIndex:skip, Count:take));
            }
            catch (Exception ex)
            {
                await _errorServiceHandler.Save(ex.Message, ex.StackTrace, ErrorTypeEnum.Exception);
                throw;
            }
        }
    }
}
