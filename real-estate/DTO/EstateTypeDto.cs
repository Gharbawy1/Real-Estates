using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace real_estate.DTO
{
    public class EstateTypeDto
    {
        [Required]
        public string Name { get; set; }
    }
}
