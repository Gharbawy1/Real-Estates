using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using real_estate.DTO;
using real_estate.Models;
using real_estate.Models.ApplicationContext;

namespace real_estate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly RealEstateDbContext _realEstateDbContext;
        public OwnerController(RealEstateDbContext realEstateDbContext)
        {
            _realEstateDbContext = realEstateDbContext;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddOwner([FromBody] OwnerDto ownerDtoFromReq)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var owner = new Owner
            {
                Name = ownerDtoFromReq.Name,
                Email = ownerDtoFromReq.Email,
                PhoneNumber = ownerDtoFromReq.PhoneNumber,
                AdditionalContactInfo = ownerDtoFromReq.AdditionalContactInfo
            };

            _realEstateDbContext.Owners.Add(owner);
            await _realEstateDbContext.SaveChangesAsync();

            return Ok(owner);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateOwner(int id, [FromBody] OwnerDto model)
        {
            var owner = await _realEstateDbContext.Owners.FindAsync(id);
            if (owner == null) return NotFound("المالك غير موجود.");

            owner.Name = model.Name;
            owner.Email = model.Email;
            owner.PhoneNumber = model.PhoneNumber;
            owner.AdditionalContactInfo = model.AdditionalContactInfo;

            await _realEstateDbContext.SaveChangesAsync();
            return Ok(owner);
        }
        [HttpDelete("delete-owner/{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var owner = await _realEstateDbContext.Owners.FindAsync(id);
            if (owner == null) return NotFound("المالك غير موجود.");

            

            _realEstateDbContext.Owners.Remove(owner);
            await _realEstateDbContext.SaveChangesAsync();

            return Ok("تم حذف المالك والعقارات المرتبطة به بنجاح.");
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllOwners()
        {
            var owners = await _realEstateDbContext.Owners.ToListAsync();
            return Ok(owners);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetOwnerById(int id)
        {
            var owner = await _realEstateDbContext.Owners.Include(o => o.RealEstates).FirstOrDefaultAsync(o => o.Id == id);
            if (owner == null) return NotFound("المالك غير موجود.");

            return Ok(owner);
        }
    }
}
