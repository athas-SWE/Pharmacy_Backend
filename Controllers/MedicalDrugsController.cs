using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Context;
using Pharmacy.Dtos;
using Pharmacy.Entities;

namespace Pharmacy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalDrugsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly MedicalDrugsEntity newMedicalDrug;
        private object newDrug;

        public MedicalDrugsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //CRUD

        //Create
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> CreateDrugs([FromBody] CreateUpdateMedicalDrugsDto dto)
        {
            var newProduct = new MedicalDrugsEntity()
            {
                Drugs = dto.Drugs,
                Name = dto.Name,
            };

            await _context.MedicalDrugs.AddAsync(newMedicalDrug);
            await _context.SaveChangesAsync();

            return Ok("Product Saved Successfully");
        }


        //Read
        [HttpGet]
        public async Task<ActionResult<List<MedicalDrugsEntity>>> GetAllMedicalDrugs()
        {
            var medicalDrugs = await _context.MedicalDrugs.OrderByDescending(q => q.UpdatedAt).ToListAsync();

            return Ok(medicalDrugs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<MedicalDrugsEntity>> GetMedicalDrugByID([FromRoute] long id)
        {
            var medicalDrugs = await _context.MedicalDrugs.FirstOrDefaultAsync(q => q.Id == id);

            if (medicalDrugs is null)
            {
                return NotFound("Medical Drugs Not Found");
            }

            return Ok(medicalDrugs);
        }


        //Update
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UdpateMedicalDrugs([FromRoute] long id, [FromBody] CreateUpdateMedicalDrugsDto dto)
        {
            var medicalDrugs = await _context.MedicalDrugs.FirstOrDefaultAsync(q => q.Id == id);

            if (medicalDrugs is null)
            {
                return NotFound("Medical Drugs Not Found");
            }

            medicalDrugs.Name = dto.Name;
            medicalDrugs.Drugs = dto.Drugs;
            medicalDrugs.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok("Medical Drugs Updated Successfully");
        }

        //Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMedicalDrugs([FromRoute] long id)
        {
            var medicalDrugs = await _context.MedicalDrugs.FirstOrDefaultAsync(q => q.Id == id);

            if (medicalDrugs is null)
            {
                return NotFound("Medical Drugs Not Found");
            }

            _context.MedicalDrugs.Remove(medicalDrugs);
            await _context.SaveChangesAsync();

            return Ok("Medical Drugs Deleted Successfully");
        }
    }
}
