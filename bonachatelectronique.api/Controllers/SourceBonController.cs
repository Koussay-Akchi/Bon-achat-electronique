using bonachatelectronique.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.api.Interfaces;

namespace bonachatelectronique.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SourceBonController : ControllerBase
    {
        private readonly ISourceBonService _sourceBonService;

        public SourceBonController(ISourceBonService sourceBonService)
        {
            _sourceBonService = sourceBonService;
        }

        /// <summary>
        /// Récupère une liste de tout les Sources des bons.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SourceBon>>> GetAllSourceBon()
        {
            var sourceBonList = await _sourceBonService.GetAllSourceBonAsync();
            return Ok(sourceBonList);
        }

        /// <summary>
        /// Récupère une Source par son Code.
        /// </summary>
        [HttpGet("{Code}")]
        public async Task<ActionResult<SourceBon>> GetSourceBonById(int Code)
        {
            var sourceBon = await _sourceBonService.GetSourceBonByIdAsync(Code);
            if (sourceBon == null)
            {
                return NotFound();
            }
            return Ok(sourceBon);
        }

        /// <summary>
        /// Ajoute une nouvelle Source.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<SourceBon>> AddSourceBon(SourceBon sourceBon)
        {
            await _sourceBonService.AddSourceBonAsync(sourceBon);
            return CreatedAtAction(nameof(GetSourceBonById), new { Code = sourceBon.Code }, sourceBon);
        }

        /// <summary>
        /// Supprime une Source par son Code.
        /// </summary>
        [HttpDelete("{Code}")]
        public async Task<ActionResult> DeleteSourceBon(int Code)
        {
            var existingSourceBon = await _sourceBonService.GetSourceBonByIdAsync(Code);
            if (existingSourceBon == null)
            {
                return NotFound();
            }

            await _sourceBonService.DeleteSourceBonAsync(Code);
            return NoContent();
        }

        /// <summary>
        /// Met à jour une Source.
        /// </summary>
        [HttpPut("{code}")]
        public async Task<ActionResult> UpdateSourceBon(int code, SourceBon SourceBon)
        {
            if (code != SourceBon.Code)
            {
                return BadRequest();
            }

            var existingSourceBon = await _sourceBonService.GetSourceBonByIdAsync(code);
            if (existingSourceBon == null)
            {
                return NotFound();
            }

            existingSourceBon.Libelle = SourceBon.Libelle;


            await _sourceBonService.UpdateSourceBonAsync(code, existingSourceBon);
            return NoContent();
        }
    }
}
