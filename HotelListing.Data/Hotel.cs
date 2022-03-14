using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.Data
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string? HotelName { get; set;}
        public string? HotelAddress { get; set;}
        public double Rating { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        public Country? Country { get; set; }

    }
}
