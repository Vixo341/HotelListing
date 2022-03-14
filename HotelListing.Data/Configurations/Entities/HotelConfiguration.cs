using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListing.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {

        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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
                    HotelName = "Grand Palldium",
                    HotelAddress = "Nassua",
                    CountryId = 2,
                    Rating = 4
                }
            );;
        }
    }
}
