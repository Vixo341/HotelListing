using System.ComponentModel.DataAnnotations;

namespace HotelListing.Core.DTOs
{

    public class CreateHotelDTO
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Hotel name is too long")]
        public string? HotelName { get; set; }
        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "Hotel address is too long")]
        public string? HotelAddress { get; set; }
        [Required]
        [Range(1, 5)]
        public double Rating { get; set; }
        [Required]
        public int CountryId { get; set; }

    }

    public class UpdateHotelDTO : CreateHotelDTO
    {

    }


    public class HotelDTO : CreateHotelDTO
    {

        public int HotelId { get; set; }    
        public CountryDTO? Country { get; set; }
    }
}
