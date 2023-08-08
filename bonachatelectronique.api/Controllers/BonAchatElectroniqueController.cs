using bonachatelectronique.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.api.Interfaces;

namespace bonachatelectronique.main.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BonAchatElectroniqueController : ControllerBase
    {
        private readonly IBonAchatElectroniqueService _BonAchatElectroniqueService;

        public BonAchatElectroniqueController(IBonAchatElectroniqueService BonAchatElectroniqueService)
        {
            _BonAchatElectroniqueService = BonAchatElectroniqueService;
        }
        /// <summary>
        /// Récupère une liste de tout les Bons d'achats.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BonAchatElectronique>>> GetAllBonAchatElectronique()
        {
            var BonAchatElectroniqueList = await _BonAchatElectroniqueService.GetAllBonAchatElectroniqueAsync();
            return Ok(BonAchatElectroniqueList);
        }
        /// <summary>
        /// Récupère un Bon d'achat par son Code.
        /// </summary>
        [HttpGet("{Id}")]
        public async Task<ActionResult<BonAchatElectronique>> GetBonAchatElectroniqueById(int Id)
        {
            var BonAchatElectronique = await _BonAchatElectroniqueService.GetBonAchatElectroniqueByIdAsync(Id);
            if (BonAchatElectronique == null)
            {
                return NotFound();
            }
            return Ok(BonAchatElectronique);
        }
        /// <summary>
        /// Ajoute un nouvelle Bon d'achat.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<BonAchatElectronique>> AddBonAchatElectronique(BonAchatElectronique BonAchatElectronique)
        {
            await _BonAchatElectroniqueService.AddBonAchatElectroniqueAsync(BonAchatElectronique);
            return CreatedAtAction(nameof(GetBonAchatElectroniqueById), new { Id = BonAchatElectronique.Id }, BonAchatElectronique);
        }
        /// <summary>
        /// Supprime un Bon d'achat par son Code.
        /// </summary>
        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteBonAchatElectronique(int Id)
        {
            var existingBonAchatElectronique = await _BonAchatElectroniqueService.GetBonAchatElectroniqueByIdAsync(Id);
            if (existingBonAchatElectronique == null)
            {
                return NotFound();
            }

            await _BonAchatElectroniqueService.DeleteBonAchatElectroniqueAsync(Id);
            return NoContent();
        }
        /// <summary>
        /// Met à jour un Bon d'achat.
        /// </summary>
        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateBonAchatElectronique(int Id, BonAchatElectronique BonAchatElectronique)
        {
            if (Id != BonAchatElectronique.Id)
            {
                return BadRequest();
            }

            var existingBonAchatElectronique = await _BonAchatElectroniqueService.GetBonAchatElectroniqueByIdAsync(Id);
            if (existingBonAchatElectronique == null)
            {
                return NotFound();
            }

            existingBonAchatElectronique.IdUtilisateur = BonAchatElectronique.IdUtilisateur;
            existingBonAchatElectronique.SoldeCarteUtilisateurAvant = BonAchatElectronique.SoldeCarteUtilisateurAvant;
            existingBonAchatElectronique.SoldeCarteUtilisateurApres = BonAchatElectronique.SoldeCarteUtilisateurApres;
            existingBonAchatElectronique.DateGeneration = BonAchatElectronique.DateGeneration;
            existingBonAchatElectronique.CodeEtat = BonAchatElectronique.CodeEtat;
            existingBonAchatElectronique.CodeType = BonAchatElectronique.CodeType;
            existingBonAchatElectronique.ValeurInitiale = BonAchatElectronique.ValeurInitiale;
            existingBonAchatElectronique.ValeurRestante = BonAchatElectronique.ValeurRestante;
            existingBonAchatElectronique.EmailBeneficiaire = BonAchatElectronique.EmailBeneficiaire;
            existingBonAchatElectronique.TelephoneBeneficiaire = BonAchatElectronique.TelephoneBeneficiaire;
            existingBonAchatElectronique.CodeSource = BonAchatElectronique.CodeSource;

            await _BonAchatElectroniqueService.UpdateBonAchatElectroniqueAsync(Id, existingBonAchatElectronique);
            return NoContent();
        }
    }
}
