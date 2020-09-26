using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo2.CircuitBreakers;
using ApiDemo2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo2.Controllers
{
    [Produces("application/json")]
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ApiDemo1CircuitBreaker apiDemo1CircuitBreaker = null;

        public SalesController(ApiDemo1CircuitBreaker apiDemo1CircuitBreaker)
        {
            this.apiDemo1CircuitBreaker = apiDemo1CircuitBreaker;
        }

        [HttpPost("productlist")]
        public async Task<IActionResult> ProductList()
        {
            try
            {
                try
                {
                    var productData = await apiDemo1CircuitBreaker?.GetProductsDataAsync();

                    if (productData != null) return base.Ok(productData);
                }
                catch (Exception ex)
                {
                    return base.BadRequest(new { ErrorMessage = ex.Message, StatusCode = 400 });
                }
            }
            catch
            {
                throw;
            }

            return base.NotFound();
        }
    }
}