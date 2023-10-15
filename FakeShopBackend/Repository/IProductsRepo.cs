using FakeShopBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeShopBackend.Repository
{
    public interface IProductsRepo
    {
        Task<IEnumerable<FakeShopModel>> GetAllProducts();
    }
}
