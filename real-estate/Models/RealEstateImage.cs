using System.ComponentModel.DataAnnotations;

namespace real_estate.Models
{
    public class RealEstateImage
    {
        public string Url { get; set; } = null!;

        [Key]
        public string PublicId { get; set; } = null!;

        public int RealEstateId { get; set; }
        public RealEstate RealEstate { get; set; } = null!;

    }
}
