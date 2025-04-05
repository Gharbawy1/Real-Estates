using AutoMapper;
using real_estate.DTO;
using real_estate.Models;

namespace real_estate.profiles
{
    public class RealEstateProfile:Profile
    {
        public RealEstateProfile() { 
            CreateMap<RealEstateDto, RealEstateGetAllResponseDto > ();

            CreateMap<RealEstate, RealEstateGetAllResponseDto>()
                .ForMember(dest => dest.TypeName,
                           opt => opt.MapFrom(src => src.EstateType.Name));

            //CreateMap<List<RealEstateImage>, List<string>>();


            // Mapping for images 
            //CreateMap<RealEstateImage, UploadedImageDto>();
            //CreateMap<UploadedImageDto, RealEstateImage>();

        }
    }
}
