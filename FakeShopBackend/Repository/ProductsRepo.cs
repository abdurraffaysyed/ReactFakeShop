using FakeShopBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeShopBackend.Repository
{
    public class ProductsRepo :IProductsRepo
    {
        private FakeShopDbContext dbContext;
        public ProductsRepo(FakeShopDbContext context)
        {
            dbContext = context;
        }
        public async Task<IEnumerable<FakeShopModel>> GetAllProducts()
        {
            //var prods = await dbContext.products.Include(p=>p.rating).ToListAsync();
            //foreach(var p in prods)
            //{
            //    await dbContext.Entry(p).Reference(ps => ps.image).LoadAsync();

            //}
            //return prods;
            
            return await dbContext.products.Include(prods => prods.rating).ToListAsync();
        }
    }
}
