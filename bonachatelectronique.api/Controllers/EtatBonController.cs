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
    public class EtatBonController : ControllerBase
    {
        private readonly bonachatelectronique.Repo.IEtatBonRepo _etatBonRepo;

        public EtatBonController(IEtatBonRepo etatBonRepo)
        {
            _etatBonRepo = etatBonRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtatBon>>> GetAllEtatBon()
        {

            var etatBonList = await _etatBonRepo.GetAllEtatBonAsync();
            return Ok(etatBonList);
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<EtatBon>> GetEtatBonById(int code)
        {
            var etatBon = await _etatBonRepo.GetEtatBonByIdAsync(code);
            if (etatBon == null)
            {
                return NotFound();
            }
            return Ok(etatBon);
        }

        [HttpPost]
        public async Task<ActionResult<EtatBon>> AddEtatBon(EtatBon etatBon)
        {
            await _etatBonRepo.AddEtatBonAsync(etatBon);
            return CreatedAtAction(nameof(GetEtatBonById), new { code = etatBon.Code }, etatBon);
        }

        [HttpDelete("{code}")]
        public async Task<ActionResult> DeleteEtatBon(int code)
        {
            var existingEtatBon = await _etatBonRepo.GetEtatBonByIdAsync(code);
            if (existingEtatBon == null)
            {
                return NotFound();
            }

            await _etatBonRepo.DeleteEtatBonAsync(code);
            return NoContent();
        }

        [HttpPut("{code}")]
        public async Task<ActionResult> UpdateEtatBon(int code, EtatBon etatBon)
        {
            if (code != etatBon.Code)
            {
                return BadRequest();
            }

            var existingEtatBon = await _etatBonRepo.GetEtatBonByIdAsync(code);
            if (existingEtatBon == null)
            {
                return NotFound();
            }

            existingEtatBon.Libelle = etatBon.Libelle;
            existingEtatBon.Description = etatBon.Description;
            existingEtatBon.Couleur = etatBon.Couleur;
            
            
            await _etatBonRepo.UpdateEtatBonAsync(existingEtatBon);
            return NoContent();
        }
    }
}
