using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace real_estate.Models
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public string AdditionalContactInfo { get; set; } // أي معلومات تواصل إضافية

        public List<RealEstate> RealEstates { get; set; } = new List<RealEstate>();


    }
}
