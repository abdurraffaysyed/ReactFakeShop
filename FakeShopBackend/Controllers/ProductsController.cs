using FakeShopBackend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace FakeShopBackend.Controllers
{
    [Route("api/products/")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsRepo productsRepo;
        private IMemoryCache _cache;
        private IDistributedCache _distributedCache;
        public ProductsController(IProductsRepo repo, IMemoryCache cache, IDistributedCache distcache)
        {
            productsRepo = repo;
            _cache = cache;
            _distributedCache = distcache;
        }

        [HttpGet("getallproducts")]
        public async Task<ActionResult> GetAllProducts(IDistributedCache distributedCache)
        {
            var products = await productsRepo.GetAllProducts();
            var p = await _cache.GetOrCreateAsync("product", async _ => await productsRepo.GetAllProducts());
            var serialisedobject = JsonConvert.SerializeObject(products);
            await distributedCache.SetAsync("products", Encoding.UTF8.GetBytes(serialisedobject));
            if(p.Any())
            {
                return Ok(p);
            }
            return BadRequest(p);
        }
    }
}
