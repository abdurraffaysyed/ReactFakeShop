using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FakeShopBackend.Models
{
    public class FakeShopModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int product_id { get; set; }
        public string title { get; set; }
        public float price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public Rating rating { get; set; }

    }
    public class FakeShopDbContext : DbContext
    {
        public FakeShopDbContext(DbContextOptions<FakeShopDbContext> options): base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder builder)
        //{
        //    builder.UseLazyLoadingProxies().UseMySql("DefaultConnection");
        //}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Rating>().HasKey(key => new { key.rate, key.product_id });
            builder.Entity<FakeShopModel>().HasOne(shop => shop.rating).WithOne().HasForeignKey<Rating>(r=>r.product_id);
        }
        public DbSet<FakeShopModel> products { get; set; }
        public DbSet<Rating> products_rating { get; set; }
    }
}
