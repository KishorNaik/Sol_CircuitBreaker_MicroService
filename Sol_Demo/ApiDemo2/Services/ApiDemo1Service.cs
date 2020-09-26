using ApiDemo2.Models;
using Newtonsoft.Json;
using Polly;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiDemo2.Services
{
    public sealed class ApiDemo1Service : IApiDemo1Service
    {
        private readonly HttpClient httpClient = null;

        public ApiDemo1Service(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        async Task<IEnumerable<ProductModel>> IApiDemo1Service.GetProductsDataAsync()
        {
            try
            {
                using var response = await httpClient.PostAsync("api/product/getproduct", null);

                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ProductModel>>(responseString);
            }
            catch
            {
                throw;
            }
        }
    }
}