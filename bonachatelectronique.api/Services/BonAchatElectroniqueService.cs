using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.api.Interfaces;
using bonachatelectronique.Data;
using bonachatelectronique.Models;
using Microsoft.EntityFrameworkCore;

namespace bonachatelectronique.api.Services
{
    public class BonAchatElectroniqueService : IBonAchatElectroniqueService
    {
        private readonly AppDbContext _dbContext;
        private readonly IRepository<BonAchatElectronique> _bonAchatElectroniqueRepository;

        public BonAchatElectroniqueService(AppDbContext dbContext, IRepository<BonAchatElectronique> bonAchatElectroniqueRepository)
        {
            _dbContext = dbContext;
            _bonAchatElectroniqueRepository = bonAchatElectroniqueRepository;
        }

        public async Task<IEnumerable<BonAchatElectronique>> GetAllBonAchatElectroniqueAsync()
        {
            return await _dbContext.BonAchatElectronique.ToListAsync();
        }

        public async Task<BonAchatElectronique> GetBonAchatElectroniqueByIdAsync(int id)
        {
            return await _dbContext.BonAchatElectronique.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> AddBonAchatElectroniqueAsync(BonAchatElectronique bonAchatElectronique)
        {
            await _bonAchatElectroniqueRepository.AddEntity(bonAchatElectronique);
            return true;
        }

        public async Task<bool> UpdateBonAchatElectroniqueAsync(int id, BonAchatElectronique bonAchatElectronique)
        {
            var existingBonAchatElectronique = await _dbContext.BonAchatElectronique.FirstOrDefaultAsync(u => u.Id == id);

            if (existingBonAchatElectronique == null)
            {
                return false;
            }

            // Update properties here

            await _bonAchatElectroniqueRepository.UpdateEntity(existingBonAchatElectronique);
            return true;
        }

        public async Task<bool> DeleteBonAchatElectroniqueAsync(int id)
        {
            var existingBonAchatElectronique = await _dbContext.BonAchatElectronique.FirstOrDefaultAsync(u => u.Id == id);

            if (existingBonAchatElectronique == null)
            {
                return false;
            }

            await _bonAchatElectroniqueRepository.DeleteEntity(id);
            return true;
        }
    }
}
