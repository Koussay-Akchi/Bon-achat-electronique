using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.api.Interfaces;
using bonachatelectronique.Data;
using bonachatelectronique.Models;
using Microsoft.EntityFrameworkCore;

namespace bonachatelectronique.api.Services
{
    public class SourceBonService : ISourceBonService
    {
        private readonly AppDbContext _dbContext;
        private readonly IRepository<SourceBon> _sourceBonRepository;

        public SourceBonService(AppDbContext dbContext, IRepository<SourceBon> sourceBonRepository)
        {
            _dbContext = dbContext;
            _sourceBonRepository = sourceBonRepository;
        }

        public async Task<IEnumerable<SourceBon>> GetAllSourceBonAsync()
        {
            return await _dbContext.SourceBon.ToListAsync();
        }

        public async Task<SourceBon> GetSourceBonByIdAsync(int code)
        {
            return await _dbContext.SourceBon.FirstOrDefaultAsync(u => u.Code == code);
        }

        public async Task<bool> AddSourceBonAsync(SourceBon sourceBon)
        {
            await _sourceBonRepository.AddEntity(sourceBon);
            return true;
        }

        public async Task<bool> UpdateSourceBonAsync(int code, SourceBon sourceBon)
        {
            var existingSourceBon = await _dbContext.SourceBon.FirstOrDefaultAsync(u => u.Code == code);

            if (existingSourceBon == null)
            {
                return false;
            }

            existingSourceBon.Libelle = sourceBon.Libelle;

            await _sourceBonRepository.UpdateEntity(existingSourceBon);
            return true;
        }

        public async Task<bool> DeleteSourceBonAsync(int code)
        {
            var existingSourceBon = await _dbContext.SourceBon.FirstOrDefaultAsync(u => u.Code == code);

            if (existingSourceBon == null)
            {
                return false;
            }

            await _sourceBonRepository.DeleteEntity(code);
            return true;
        }
    }
}
