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
    }
}
