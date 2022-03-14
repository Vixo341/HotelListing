using System.ComponentModel.DataAnnotations;

namespace HotelListing.Core.DTOs
{
    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Country name is too long")]
        public string? CountryName { get; set; }
        [Required]
        [StringLength(maximumLength: 3, ErrorMessage = "Short country is too long")]
        public string? ShortName { get; set; }
    }

    public class UpdateCountryDTO : CreateCountryDTO
    {
        public IList<CreateHotelDTO> Hotels { get; set; }
    }

    public class CountryDTO : CreateCountryDTO
    {
        public int CountryId { get; set; }
        public virtual IList<HotelDTO>? Hotels { get; set;}
    }
}
