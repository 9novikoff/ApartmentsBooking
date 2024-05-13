using ApartmentsBooking.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApartmentsBooking.DAL;

public class ApartmentBookingContext : IdentityDbContext<IdentityUser>
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    
    public ApartmentBookingContext(DbContextOptions<ApartmentBookingContext> options) : base(options)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //DATA SEED
        modelBuilder.Entity<Country>().HasData(new Country
        {
            Id = 1, Name = "Ukraine"
        });
        modelBuilder.Entity<City>().HasData(new City
        {
            Id = 1, Name = "Kyiv", CountryId = 1
        });
        modelBuilder.Entity<Apartment>().HasData(new Apartment
        {
            Id = 1, ApartmentType = 0, CityId = 1, IsAvailable = true, PrizePerHour = 1
        });
        modelBuilder.Entity<Booking>().HasData(new Booking
        {
            Id = 1, ApartmentId = 1, UserId = "da9b5c6a-a9a1-4c56-a782-15e7fba86918", TimeFrom = DateTime.Now,
            TimeTo = DateTime.Now.AddDays(10)
        });

    }
}