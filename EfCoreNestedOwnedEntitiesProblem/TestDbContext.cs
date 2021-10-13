using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfCoreNestedOwnedEntitiesProblem
{
    public class TestDbContext : DbContext
    {
        public DbSet<EntityOne> EntityOnes { get; set; }
        public DbSet<EntityTwo> EntityTwos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=127.0.0.1,5433;Initial Catalog=XXX;User Id=XXX;Password=XXX")
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityOne>(b =>
            {
                b.OwnsOne(x => x.MyProp, lvlOneBuilder =>
                {
                    lvlOneBuilder.OwnsOne(x => x.LvlTwo, lvlTwoBuilder =>
                    {
                        lvlTwoBuilder.OwnsOne(x => x.LvlThree);
                    });
                });
            });

            modelBuilder.Entity<EntityTwo>(b =>
            {
                b.OwnsOne(x => x.MyOtherProp, lvlOneBuilder =>
                {
                    lvlOneBuilder.OwnsOne(x => x.LvlTwo, lvlTwoBuilder =>
                    {
                        lvlTwoBuilder.OwnsOne(x => x.LvlThree);
                    });
                });
            });
        }
    }
}