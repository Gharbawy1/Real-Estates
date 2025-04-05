using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace real_estate.Models
{
    public class EstateType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // خلي الـ ID يتولد تلقائيًا
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } // اسم نوع العقار (شقة، فيلا، محل...)

        [JsonIgnore]
        public List<RealEstate>? RealEstates { get; set; }
        //محتاج اظبط ال owner واعمله Test كويس 
        // ثم ال realestate

    }
}
