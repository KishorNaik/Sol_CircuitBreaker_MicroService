using ApiDemo2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemo2.Services
{
    public interface IApiDemo1Service
    {
        Task<IEnumerable<ProductModel>> GetProductsDataAsync();
    }
}