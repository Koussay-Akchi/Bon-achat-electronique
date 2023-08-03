using bonachatelectronique.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.Repo;

namespace bonachatelectronique.main.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeBonController : ControllerBase
    {
        private readonly bonachatelectronique.Repo.ITypeBonRepo _TypeBonRepo;

        public TypeBonController(ITypeBonRepo TypeBonRepo)
        {
            _TypeBonRepo = TypeBonRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeBon>>> GetAllTypeBon()
        {

            var TypeBonList = await _TypeBonRepo.GetAllTypeBonAsync();
            return Ok(TypeBonList);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<TypeBon>> GetTypeBonById(int code)
        {
            var TypeBon = await _TypeBonRepo.GetTypeBonByIdAsync(code);
            if (TypeBon == null)
            {
                return NotFound();
            }
            return Ok(TypeBon);
        }

        [HttpPost]
        public async Task<ActionResult<TypeBon>> AddTypeBon(TypeBon TypeBon)
        {
            await _TypeBonRepo.AddTypeBonAsync(TypeBon);
            return CreatedAtAction(nameof(GetTypeBonById), new { code = TypeBon.Code }, TypeBon);
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> DeleteTypeBon(int code)
        {
            var existingTypeBon = await _TypeBonRepo.GetTypeBonByIdAsync(code);
            if (existingTypeBon == null)
            {
                return NotFound();
            }

            await _TypeBonRepo.DeleteTypeBonAsync(code);
            return NoContent();
        }

        [HttpPut("{code}")]
        public async Task<ActionResult> UpdateTypeBon(int code, TypeBon TypeBon)
        {
            if (code != TypeBon.Code)
            {
                return BadRequest();
            }

            var existingTypeBon = await _TypeBonRepo.GetTypeBonByIdAsync(code);
            if (existingTypeBon == null)
            {
                return NotFound();
            }

            existingTypeBon.Libelle = TypeBon.Libelle;
            
            
            await _TypeBonRepo.UpdateTypeBonAsync(existingTypeBon);
            return NoContent();
        }
    }
}
