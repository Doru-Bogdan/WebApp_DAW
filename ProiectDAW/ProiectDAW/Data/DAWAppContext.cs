using DAW.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAW.Data
{
    public class DAWAppContext : DbContext
    {
        public DAWAppContext(DbContextOptions<DAWAppContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarLoan> CarLoans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasOne(x => x.UserDetails)
                .WithOne(y => y.User)
                .HasForeignKey<UserDetails>
                (z => z.UserId);
                
            builder.Entity<CarBrand>()
                .HasMany(x => x.Vehicles)
                .WithOne(y => y.CarBrand)
                .HasForeignKey(x => x.CarBrandId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasMany(x => x.CarLoans)
                .WithOne(y => y.User)
                .HasForeignKey(z => z.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Vehicle>()
                .HasMany(x => x.CarLoans)
                .WithOne(y => y.Vehicle)
                .HasForeignKey(z => z.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
