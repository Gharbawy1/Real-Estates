using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace real_estate.Models
{
    public class RealEstateImage
    {
        public string Url { get; set; } = null!;

        [Key]
        public string PublicId { get; set; } = null!;

        [JsonIgnore]
        public int RealEstateId { get; set; }
        [JsonIgnore]

        public RealEstate? RealEstate { get; set; } = null!;

    }
}
