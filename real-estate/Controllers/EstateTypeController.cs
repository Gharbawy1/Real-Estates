using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using real_estate.DTO;
using real_estate.Models;
using real_estate.Models.ApplicationContext;

namespace real_estate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateTypeController : ControllerBase
    {
        private readonly RealEstateDbContext _context;

        public EstateTypeController(RealEstateDbContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<EstateType>>> GetEstateTypes()
        {
            return await _context.EstateTypes.ToListAsync();
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ActionResult<EstateType>> GetById(int id)
        {
            return await _context.EstateTypes.FindAsync(id);
        }

        [HttpPost("add")]
        public async Task<ActionResult<EstateType>> AddEstateType([FromBody] EstateType estateType)
        {
            if (_context.EstateTypes.Any(et => et.Name == estateType.Name))
            {
                return BadRequest("هذا النوع موجود بالفعل.");
            }

            var newEstate = new EstateType()
            {
                Name = estateType.Name,
            };

            _context.EstateTypes.Add(newEstate);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEstateTypes), new { Name = estateType.Name }, estateType);
        }

        [HttpPut("update/{oldTypeId}")]
        public async Task<IActionResult> UpdateEstateType(int oldTypeId,[FromBody] string newName)
        {
            var existingType = await _context.EstateTypes.FindAsync(oldTypeId);
            if (existingType == null) return NotFound("نوع العقار غير موجود.");

            existingType.Name = newName;
            await _context.SaveChangesAsync();
            return Ok("تم تحديث نوع العقار بنجاح.");
        }

        [HttpDelete("delete/{TypeId}")]
        public async Task<IActionResult> DeleteEstateType(int TypeId)
        {
            var estateType = await _context.EstateTypes.FindAsync(TypeId);
            if (estateType == null) return NotFound("نوع العقار غير موجود.");

            if (_context.RealEstates.Any(r => r.Id == TypeId))
            {
                return BadRequest("لا يمكن حذف هذا النوع لأنه مرتبط بعقارات.");
            }

            _context.EstateTypes.Remove(estateType);
            await _context.SaveChangesAsync();
            return Ok("تم حذف نوع العقار بنجاح.");
        }
    }
}
