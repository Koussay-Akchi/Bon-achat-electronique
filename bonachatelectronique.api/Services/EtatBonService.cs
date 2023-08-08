using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.api.Interfaces;
using bonachatelectronique.Data;
using bonachatelectronique.Models;
using Microsoft.EntityFrameworkCore;

namespace bonachatelectronique.api.Services
{
    public class EtatBonService : IEtatBonService
    {
        private readonly AppDbContext _dbContext;
        private readonly IRepository<EtatBon> _etatBonRepository;

        public EtatBonService(AppDbContext dbContext, IRepository<EtatBon> etatBonRepository)
        {
            _dbContext = dbContext;
            _etatBonRepository = etatBonRepository;
        }

        public async Task<IEnumerable<EtatBon>> GetAllEtatBonAsync()
        {
            return await _dbContext.EtatBon.ToListAsync();
        }

        public async Task<EtatBon> GetEtatBonByIdAsync(int code)
        {
            return await _dbContext.EtatBon.FirstOrDefaultAsync(u => u.Code == code);
        }

        public async Task<bool> AddEtatBonAsync(EtatBon etatBon)
        {
            await _etatBonRepository.AddEntity(etatBon);
            return true;
        }

        public async Task<bool> UpdateEtatBonAsync(int code, EtatBon etatBon)
        {
            var existingEtatBon = await _dbContext.EtatBon.FirstOrDefaultAsync(u => u.Code == code);

            if (existingEtatBon == null)
            {
                return false;
            }

            existingEtatBon.Libelle = etatBon.Libelle;
            existingEtatBon.Description = etatBon.Description;
            existingEtatBon.Couleur = etatBon.Couleur;

            await _etatBonRepository.UpdateEntity(existingEtatBon);
            return true;
        }

        public async Task<bool> DeleteEtatBonAsync(int code)
        {
            var existingEtatBon = await _dbContext.EtatBon.FirstOrDefaultAsync(u => u.Code == code);

            if (existingEtatBon == null)
            {
                return false;
            }

            await _etatBonRepository.DeleteEntity(code);
            return true;
        }
    }
}
