using System.ComponentModel.DataAnnotations;

namespace real_estate.DTO
{
    public class RealEstateGetAllResponseDto
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

        public string TypeName { get; set; } // نوع العقار (شقة، فيلا، محل تجاري...)

        public bool IsAvailable { get; set; } = true; // هل العقار متاح؟
    }
}
