using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    CountryId = 1,
                    CountryName = "Jamaica",
                    ShortName = "JM"
                },
                new Country
                {
                    CountryId = 2,
                    CountryName = "Bahamas",
                    ShortName = "BS"
                },
                new Country
                {
                    CountryId = 3,
                    CountryName = "Cayman Island",
                    ShortName = "CI"
                }
                );

            builder.Entity<Hotel>().HasData(
            new Hotel
            {
                HotelId = 1,
                HotelName = "Sandals Resort and Spa",
                HotelAddress = "Negril",
                CountryId = 1,
                Rating = 4.5
            },
            new Hotel
            {
                HotelId = 2,
                HotelName = "Comfort Suites",
                HotelAddress = "George Town",
                CountryId = 3,
                Rating = 4.3
            },
            new Hotel
            {
                HotelId = 3,
                HotelName = "Grand Plldium",
                HotelAddress = "Nassua",
                CountryId = 2,
                Rating = 4
            }
            ) ;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
