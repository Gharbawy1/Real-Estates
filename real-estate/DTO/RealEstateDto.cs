using real_estate.Models;
using System.ComponentModel.DataAnnotations;

namespace real_estate.DTO
{
    public class RealEstateDto
    {
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

        public int TypeId { get; set; } // نوع العقار (شقة، فيلا، محل تجاري...)

        public bool IsAvailable { get; set; } = true; // هل العقار متاح؟

        public ICollection<IFormFile> Images { get; set; } // صور العقار

        public int OwnerId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
