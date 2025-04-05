using AutoMapper;
using real_estate.DTO;
using real_estate.Models;

namespace real_estate.profiles
{
    public class RealEstateProfile:Profile
    {
        public RealEstateProfile() { 
            CreateMap<RealEstateDto, RealEstateGetAllResponseDto > ();

            // Mapping for images 
            CreateMap<List<UploadedImageDto>, List<RealEstateImage>>();
        
        }
    }
}
