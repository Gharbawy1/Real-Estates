using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using real_estate.DTO;
using real_estate.Models;
using real_estate.Models.ApplicationContext;
using real_estate.Service;
using System.Xml;

namespace real_estate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly RealEstateDbContext _realEstateDbContext;
        private readonly IImageUploadService _cloudinaryImageUploadService;
        private readonly IMapper _mapper;

        public RealEstateController(IImageUploadService cloudinaryImageUploadService, RealEstateDbContext realEstateDbContext, IMapper mapper)
        {
            _cloudinaryImageUploadService = cloudinaryImageUploadService;
            _realEstateDbContext = realEstateDbContext;
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<RealEstate>>> GetAll(
    //[FromQuery] int? estateTypeId,
    //[FromQuery] bool? isAvailable,
    //[FromQuery] string? sortByPrice,
    //[FromQuery] int pageNumber = 1,
    //[FromQuery] int pageSize = 10
            
            )
        {
            var query = await _realEstateDbContext.RealEstates
                //.Include(re => re.EstateType)
                //.Include(re => re.Owner)
                .Include(rs=>rs.Images)
                .ToListAsync();

            //// فلترة حسب نوع العقار
            //if (estateTypeId.HasValue)
            //    query = query.Where(re => re.EstateTypeId == estateTypeId.Value);

            //// فلترة حسب الحالة
            //if (isAvailable.HasValue)
            //    query = query.Where(re => re.IsAvailable == isAvailable.Value);

            //// الترتيب حسب السعر لو مستخدم طلبه
            //if (!string.IsNullOrEmpty(sortByPrice))
            //{
            //    if (sortByPrice.ToLower() == "asc")
            //        query = query.OrderBy(re => re.Price);
            //    else if (sortByPrice.ToLower() == "desc")
            //        query = query.OrderByDescending(re => re.Price);
            //}

            //var totalCount = await query.CountAsync();

            //var estates = await query
            //    .Skip((pageNumber - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToListAsync();

            //var mappedEstates = _mapper.Map<List<RealEstateGetAllResponseDto>>(estates);

            //return Ok(new
            //{
            //    TotalCount = totalCount,
            //    PageNumber = pageNumber,
            //    PageSize = pageSize,
            //    Data = mappedEstates
            //});
            return query;
        }



        [HttpPost("add")]
        public async Task<IActionResult> AddRealEstate([FromForm] RealEstateDto EstateFromReq)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var imagesWithPublicIds = new Dictionary<string, string>();

            // upload images on cloudinary
            if (EstateFromReq.Images.Count > 0)
            {
                // upload all images 
                imagesWithPublicIds = await _cloudinaryImageUploadService.UploadAsync(EstateFromReq.Images);
            }

            var realEstate = new RealEstate
            {
                Title = EstateFromReq.Title,
                Description = EstateFromReq.Description,
                Address = EstateFromReq.Address,
                Price = EstateFromReq.Price,
                Area = EstateFromReq.Area,
                Bedrooms = EstateFromReq.Bedrooms,
                Bathrooms = EstateFromReq.Bathrooms,
                EstateType = EstateFromReq.EstateType,
                IsAvailable = EstateFromReq.IsAvailable,
                OwnerName = EstateFromReq.OwnerName,
                CreatedAt = DateTime.UtcNow
            };
            foreach (var image in imagesWithPublicIds) {

                realEstate.Images.Add(new RealEstateImage { Url = image.Key,PublicId = image.Value });
            }
            _realEstateDbContext.RealEstates.Add(realEstate);
            await _realEstateDbContext.SaveChangesAsync();

            return Ok(realEstate);
        }



        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] RealEstateDto EstateFromReq)
        {
            var estate = await _realEstateDbContext.RealEstates.FindAsync(id);
            if (estate == null) return NotFound($"Real estate with ID {id} not found.");

            // تحديث الصور لو المستخدم بعث صور جديدة
            if (EstateFromReq.Images != null && EstateFromReq.Images.Count > 0)
            {
                var imagesWithPublicIds = new Dictionary<string, string>();
                await _cloudinaryImageUploadService.UploadAsync(EstateFromReq.Images);
                foreach (var image in imagesWithPublicIds)
                {

                    estate.Images.Add(new RealEstateImage { Url = image.Key, PublicId = image.Value });
                }
            }

            estate.Title = EstateFromReq.Title;
            estate.Description = EstateFromReq.Description;
            estate.Address = EstateFromReq.Address;
            estate.Price = EstateFromReq.Price;
            estate.Area = EstateFromReq.Area;
            estate.Bedrooms = EstateFromReq.Bedrooms;
            estate.Bathrooms = EstateFromReq.Bathrooms;
            estate.EstateType = EstateFromReq.EstateType;
            estate.IsAvailable = EstateFromReq.IsAvailable;
            estate.OwnerName = EstateFromReq.OwnerName;

            _realEstateDbContext.RealEstates.Update(estate);
            await _realEstateDbContext.SaveChangesAsync();

            return Ok(estate);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var estate = await _realEstateDbContext.RealEstates
                .Include(e => e.Images)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (estate == null) return NotFound($"Real estate with ID {id} not found.");

            //var publicIds = estate.Images.Select(img => img.PublicId).ToList();

            //// حذف الصور من Cloudinary
            //await _cloudinaryImageUploadService.DeleteImagesAsync(publicIds);

            //_realEstateDbContext.RealEstateImages.RemoveRange(estate.Images);
            _realEstateDbContext.RealEstates.Remove(estate);
            await _realEstateDbContext.SaveChangesAsync();

            return Ok($"Real estate with ID {id} and its images deleted successfully.");
        }

    }
}
