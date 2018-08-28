using System;
using Microsoft.EntityFrameworkCore;
using CarPriceHonester.Entity.Table;

namespace CarPriceHonester.Models.Context
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<CarModel> Cars { get; set; }

        public DbSet<CarDetailModel> CarsDetail { get; set; }
    }
}
