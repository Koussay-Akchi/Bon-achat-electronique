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
    public class SourceBonController : ControllerBase
    {
        private readonly bonachatelectronique.Repo.ISourceBonRepo _SourceBonRepo;

        public SourceBonController(ISourceBonRepo SourceBonRepo)
        {
            _SourceBonRepo = SourceBonRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SourceBon>>> GetAllSourceBon()
        {

            var SourceBonList = await _SourceBonRepo.GetAllSourceBonAsync();
            return Ok(SourceBonList);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<SourceBon>> GetSourceBonById(int code)
        {
            var SourceBon = await _SourceBonRepo.GetSourceBonByIdAsync(code);
            if (SourceBon == null)
            {
                return NotFound();
            }
            return Ok(SourceBon);
        }

        [HttpPost]
        public async Task<ActionResult<SourceBon>> AddSourceBon(SourceBon SourceBon)
        {
            await _SourceBonRepo.AddSourceBonAsync(SourceBon);
            return CreatedAtAction(nameof(GetSourceBonById), new { code = SourceBon.Code }, SourceBon);
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> DeleteSourceBon(int code)
        {
            var existingSourceBon = await _SourceBonRepo.GetSourceBonByIdAsync(code);
            if (existingSourceBon == null)
            {
                return NotFound();
            }

            await _SourceBonRepo.DeleteSourceBonAsync(code);
            return NoContent();
        }

        [HttpPut("{code}")]
        public async Task<ActionResult> UpdateSourceBon(int code, SourceBon SourceBon)
        {
            if (code != SourceBon.Code)
            {
                return BadRequest();
            }

            var existingSourceBon = await _SourceBonRepo.GetSourceBonByIdAsync(code);
            if (existingSourceBon == null)
            {
                return NotFound();
            }

            existingSourceBon.Libelle = SourceBon.Libelle;
            
            
            await _SourceBonRepo.UpdateSourceBonAsync(existingSourceBon);
            return NoContent();
        }
    }
}
