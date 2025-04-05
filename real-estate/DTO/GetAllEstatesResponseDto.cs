using System.ComponentModel.DataAnnotations;

namespace real_estate.DTO
{
    public class GetAllEstatesResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public double Area { get; set; } // المساحة بالمتر المربع

        public int Bedrooms { get; set; } // عدد غرف النوم

        public int Bathrooms { get; set; } // عدد الحمامات

        public int TypeId { get; set; } // نوع العقار (شقة، فيلا، محل تجاري...)

        public bool IsAvailable { get; set; } = true; // هل العقار متاح؟

        public ICollection<string> Images { get; set; } // صور العقار

        public int OwnerId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
