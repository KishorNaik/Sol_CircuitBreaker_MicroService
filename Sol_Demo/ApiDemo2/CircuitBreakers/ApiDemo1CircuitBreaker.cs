using ApiDemo2.Models;
using ApiDemo2.Services;
using Polly;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo2.CircuitBreakers
{
    public class ApiDemo1CircuitBreaker
    {
        private readonly AsyncCircuitBreakerPolicy circuitBreakerPolicy = null;
        private readonly IApiDemo1Service apiDemo1Service = null;

        public ApiDemo1CircuitBreaker(IApiDemo1Service apiDemo1Service, AsyncCircuitBreakerPolicy circuitBreakerPolicy)
        {
            this.apiDemo1Service = apiDemo1Service;
            this.circuitBreakerPolicy = circuitBreakerPolicy;
        }

        public async Task<IEnumerable<ProductModel>> GetProductsDataAsync()
        {
            try
            {
                Console.WriteLine(circuitBreakerPolicy.CircuitState);
                return await circuitBreakerPolicy?.ExecuteAsync<IEnumerable<ProductModel>>(async () => await apiDemo1Service.GetProductsDataAsync());
            }
            catch
            {
                throw;
            }
        }
    }
}