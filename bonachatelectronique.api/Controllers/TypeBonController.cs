using bonachatelectronique.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.api.Interfaces;

namespace bonachatelectronique.main.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TypeBonController : ControllerBase
    {
        private readonly ITypeBonService _TypeBonService;

        public TypeBonController(ITypeBonService TypeBonService)
        {
            _TypeBonService = TypeBonService;
        }


        /// <summary>
        /// Récupère une liste de tout les Types des bons.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeBon>>> GetAllTypeBon()
        {
            var TypeBonList = await _TypeBonService.GetAllTypeBonAsync();
            return Ok(TypeBonList);
        }

        /// <summary>
        /// Récupère un Type par son Code.
        /// </summary>
        [HttpGet("{Code}")]
        public async Task<ActionResult<TypeBon>> GetTypeBonById(int Code)
        {
            var TypeBon = await _TypeBonService.GetTypeBonByIdAsync(Code);
            if (TypeBon == null)
            {
                return NotFound();
            }
            return Ok(TypeBon);
        }
        /// <summary>
        /// Ajoute un nouvelle Type.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<TypeBon>> AddTypeBon(TypeBon TypeBon)
        {
            await _TypeBonService.AddTypeBonAsync(TypeBon);
            return CreatedAtAction(nameof(GetTypeBonById), new { Code = TypeBon.Code }, TypeBon);
        }
        /// <summary>
        /// Supprime un Type par son Code.
        /// </summary>
        [HttpDelete("{Code}")]
        public async Task<ActionResult> DeleteTypeBon(int Code)
        {
            var existingTypeBon = await _TypeBonService.GetTypeBonByIdAsync(Code);
            if (existingTypeBon == null)
            {
                return NotFound();
            }

            await _TypeBonService.DeleteTypeBonAsync(Code);
            return NoContent();
        }
        /// <summary>
        /// Met à jour un Type.
        /// </summary>
        [HttpPut("{Code}")]
        public async Task<ActionResult> UpdateTypeBon(int Code, TypeBon TypeBon)
        {
            if (Code != TypeBon.Code)
            {
                return BadRequest();
            }

            var existingTypeBon = await _TypeBonService.GetTypeBonByIdAsync(Code);
            if (existingTypeBon == null)
            {
                return NotFound();
            }

            existingTypeBon.Libelle = TypeBon.Libelle;

            await _TypeBonService.UpdateTypeBonAsync(Code, existingTypeBon);
            return NoContent();
        }
    }
}
