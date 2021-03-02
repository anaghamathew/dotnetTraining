using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurentAppNew.Models;

namespace RestaurentAppNew.Data
{
    public class RestaurentAppNewContext : IdentityDbContext<ApplicationUser>
    {
        public RestaurentAppNewContext(DbContextOptions<RestaurentAppNewContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
       /* public RestaurentAppNewContext() : base("RestaurentAppNew");
        {
            
        }*/
        public DbSet<Category> Category { get; set; }

        public DbSet<Food> Food { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<Ingredients> Ingredients { get; set; }

       /* public DbSet<CartItem> ShoppingCartItems{get;set; }*/

    }
}
