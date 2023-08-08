using bonachatelectronique.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using bonachatelectronique.api.Interfaces;

namespace bonachatelectronique.main.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EtatBonController : ControllerBase
    {
        private readonly IEtatBonService _EtatBonService;

        public EtatBonController(IEtatBonService etatBonService)
        {
            _EtatBonService = etatBonService;
        }

        /// <summary>
        /// Récupère une liste de tous les Etats de Bon.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EtatBon>>> GetAllEtatBon()
        {
            var etatBonList = await _EtatBonService.GetAllEtatBonAsync();
            return Ok(etatBonList);
        }

        /// <summary>
        /// Récupère un Etat spécifique par son code.
        /// </summary>
        [HttpGet("{code}")]
        public async Task<ActionResult<EtatBon>> GetEtatBonById(int code)
        {
            var etatBon = await _EtatBonService.GetEtatBonByIdAsync(code);
            if (etatBon == null)
            {
                return NotFound();
            }
            return Ok(etatBon);
        }

        /// <summary>
        /// Ajoute un nouvel Etat.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<EtatBon>> AddEtatBon(EtatBon etatBon)
        {
            await _EtatBonService.AddEtatBonAsync(etatBon);
            return CreatedAtAction(nameof(GetEtatBonById), new { code = etatBon.Code }, etatBon);
        }

        /// <summary>
        /// Met à jour un Etat existant.
        /// </summary>
        [HttpPut("{code}")]
        public async Task<ActionResult> UpdateEtatBon(int code, EtatBon etatBon)
        {
            if (code != etatBon.Code)
            {
                return BadRequest();
            }

            var existingEtatBon = await _EtatBonService.GetEtatBonByIdAsync(code);
            if (existingEtatBon == null)
            {
                return NotFound();
            }

            // Mettre à jour les propriétés de l'EtatBon existant avec les nouvelles données.
            existingEtatBon.Libelle = etatBon.Libelle;
            existingEtatBon.Description = etatBon.Description;
            existingEtatBon.Couleur = etatBon.Couleur;

            await _EtatBonService.UpdateEtatBonAsync(code, existingEtatBon);
            return NoContent();
        }

        /// <summary>
        /// Supprime un Etat par son code.
        /// </summary>
        [HttpDelete("{code}")]
        public async Task<ActionResult> DeleteEtatBon(int code)
        {
            var existingEtatBon = await _EtatBonService.GetEtatBonByIdAsync(code);
            if (existingEtatBon == null)
            {
                return NotFound();
            }

            await _EtatBonService.DeleteEtatBonAsync(code);
            return NoContent();
        }
    }
}
