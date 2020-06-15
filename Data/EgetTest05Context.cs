using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EgetTest05.Models;

namespace EgetTest05.Data
{
    public class EgetTest05Context : DbContext
    {
        public EgetTest05Context (DbContextOptions<EgetTest05Context> options)
            : base(options)
        {
        }

        public DbSet<City> City { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            modelBuilder.Entity<City>()
                        .HasOne(e => e.Country)
                        .WithMany(e => e.City)
                        .HasForeignKey(e => e.CountryID);
        }
        public DbSet<EgetTest05.Models.Country> Country { get; set; }
    }
}
