using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurentAppNew.Models;

namespace RestaurentAppNew.Data
{
    public class RestaurentAppNewContext : DbContext
    {
        public RestaurentAppNewContext(DbContextOptions<RestaurentAppNewContext> options)
            : base(options)
        {
        }
       /* public RestaurentAppNewContext() : base("RestaurentAppNew");
        {
            
        }*/
        public DbSet<RestaurentAppNew.Models.Category> Category { get; set; }

        public DbSet<RestaurentAppNew.Models.Food> Food { get; set; }

        public DbSet<RestaurentAppNew.Models.PurchaseOrder> PurchaseOrder { get; set; }


        /* public DbSet<CartItem> ShoppingCartItems{get;set; }
 */
    }
}
