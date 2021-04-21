using harbour.models;
using Microsoft.EntityFrameworkCore;

namespace harbour.helpers
{
   
    public class HarbourDb : DbContext
    {
        public HarbourDb(DbContextOptions<HarbourDb> options) : base(options)
        {
        }
        public DbSet<Boat> Boat { get; set; }
        public DbSet<BoatTransaction> BoatTransaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boat>().HasData(
                new Boat {Id = 1, Name = "Speedboat", Speed = 30},
                new Boat {Id = 2, Name = "Sailboat", Speed = 15},
                new Boat {Id = 3, Name = "Cargo ship", Speed = 5}
            );
        }
    }
}

//var randomMyClass = RandomValue.Object<MyClass>();