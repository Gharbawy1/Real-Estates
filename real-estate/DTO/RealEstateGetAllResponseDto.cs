using System.ComponentModel.DataAnnotations;

namespace real_estate.DTO
{
    public class RealEstateGetAllResponseDto
    {
        public string Title { get; set; }

        
        public string Description { get; set; }

        public string Address { get; set; }

        public decimal Price { get; set; }

        public double Area { get; set; } // المساحة بالمتر المربع

        public int Bedrooms { get; set; } // عدد غرف النوم

        public int Bathrooms { get; set; } // عدد الحمامات

        public List<string> Images { get; set; }

        public string TypeName { get; set; } // نوع العقار (شقة، فيلا، محل تجاري...)

        public bool IsAvailable { get; set; } = true; // هل العقار متاح؟
    }
}
