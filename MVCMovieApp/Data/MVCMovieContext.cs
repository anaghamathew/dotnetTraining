using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCMovieApp.Models;
namespace MVCMovieApp.Data
{
    public class MVCMovieContext : DbContext
    {
        public MVCMovieContext(DbContextOptions<MVCMovieContext>options)
            : base(options)
        {

        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genr> Genr { get; set; }

        public DbSet<LicenceDetails> LicenceDetails { get; set; }


    }
}
