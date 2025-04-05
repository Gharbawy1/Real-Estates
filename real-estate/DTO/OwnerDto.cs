using System.ComponentModel.DataAnnotations;

namespace real_estate.DTO
{
    public class OwnerDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string AdditionalContactInfo { get; set; }
    }
}
