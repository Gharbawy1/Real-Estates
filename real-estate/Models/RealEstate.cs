using System.ComponentModel.DataAnnotations;

namespace real_estate.Models
{
    public class RealEstate
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        public decimal Price { get; set; }

        public double Area { get; set; } // المساحة بالمتر المربع

        public int Bedrooms { get; set; } // عدد غرف النوم

        public int Bathrooms { get; set; } // عدد الحمامات

        public int EstateTypeId { get; set; }
        public EstateType? EstateType { get; set; }

        public bool IsAvailable { get; set; } = true; // هل العقار متاح؟

        public List<RealEstateImage> Images { get; set; } // صور العقار

        public int OwnerId { get; set; }
        public Owner? Owner { get; set; } // المالك

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
