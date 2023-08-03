using bonachatelectronique.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.Repo;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace bonachatelectronique.main.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BonAchatElectroniqueController : ControllerBase
    {
        private readonly bonachatelectronique.Repo.IBonAchatElectroniqueRepo _BonAchatElectroniqueRepo;

        public BonAchatElectroniqueController(IBonAchatElectroniqueRepo BonAchatElectroniqueRepo)
        {
            _BonAchatElectroniqueRepo = BonAchatElectroniqueRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BonAchatElectronique>>> GetAllBonAchatElectronique()
        {

            var BonAchatElectroniqueList = await _BonAchatElectroniqueRepo.GetAllBonAchatElectroniqueAsync();
            return Ok(BonAchatElectroniqueList);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<BonAchatElectronique>> GetBonAchatElectroniqueById(int Id)
        {
            var BonAchatElectronique = await _BonAchatElectroniqueRepo.GetBonAchatElectroniqueByIdAsync(Id);
            if (BonAchatElectronique == null)
            {
                return NotFound();
            }
            return Ok(BonAchatElectronique);
        }

        [HttpPost]
        public async Task<ActionResult<BonAchatElectronique>> AddBonAchatElectronique(BonAchatElectronique BonAchatElectronique)
        {
            await _BonAchatElectroniqueRepo.AddBonAchatElectroniqueAsync(BonAchatElectronique);
            return CreatedAtAction(nameof(GetBonAchatElectroniqueById), new { Id = BonAchatElectronique.Id }, BonAchatElectronique);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteBonAchatElectronique(int Id)
        {
            var existingBonAchatElectronique = await _BonAchatElectroniqueRepo.GetBonAchatElectroniqueByIdAsync(Id);
            if (existingBonAchatElectronique == null)
            {
                return NotFound();
            }

            await _BonAchatElectroniqueRepo.DeleteBonAchatElectroniqueAsync(Id);
            return NoContent();
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateBonAchatElectronique(int Id, BonAchatElectronique BonAchatElectronique)
        {
            if (Id != BonAchatElectronique.Id)
            {
                return BadRequest();
            }

            var existingBonAchatElectronique = await _BonAchatElectroniqueRepo.GetBonAchatElectroniqueByIdAsync(Id);
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

            await _BonAchatElectroniqueRepo.UpdateBonAchatElectroniqueAsync(existingBonAchatElectronique);
            return NoContent();
        }
    }
}
