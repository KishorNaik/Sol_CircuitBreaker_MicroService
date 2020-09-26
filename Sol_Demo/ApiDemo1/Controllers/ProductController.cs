using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemo1.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost("getproduct")]
        public Task<IActionResult> GetProductDataAsync()
        {
            try
            {
                return Task.Run<IActionResult>(() =>
                {
                    var productList = new List<ProductModel>();
                    productList.Add(new ProductModel()
                    {
                        ProdductId = Guid.NewGuid(),
                        Name = "Chai",
                        UnitPrice = 100.50
                    });
                    productList.Add(new ProductModel()
                    {
                        ProdductId = Guid.NewGuid(),
                        Name = "Coffee",
                        UnitPrice = 150.50
                    });

                    // Assume that this service stop by some case when we consume this service in ApiDemo2 App
                    ThrowRandomException();

                    return base.Ok(productList);
                });
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        ///  This is used for the demo purpose.it will throw rondomly exception.
        ///  Stop Service based on dice so Here I can show how the circuit breaker is work in ApiDemo2.
        ///  Once the exception throw then Circuit breaker status will open and ApiDemo2 will not call ApiDemo1 until circuit breaker will not reset.
        /// </summary>
        private void ThrowRandomException()
        {
            var diceRoll = new Random().Next(0, 10);

            if (diceRoll > 5)
            {
                //Console.WriteLine("ERROR! Throwing Exception");
                throw new Exception("Exception in Product Controller");
            }
        }
    }
}