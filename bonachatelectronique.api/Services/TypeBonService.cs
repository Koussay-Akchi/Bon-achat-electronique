using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.api.Interfaces;
using bonachatelectronique.Data;
using bonachatelectronique.Models;
using Microsoft.EntityFrameworkCore;

namespace bonachatelectronique.api.Services
{
    public class TypeBonService : ITypeBonService
    {
        private readonly AppDbContext _dbContext;
        private readonly IRepository<TypeBon> _typeBonRepository;

        public TypeBonService(AppDbContext dbContext, IRepository<TypeBon> typeBonRepository)
        {
            _dbContext = dbContext;
            _typeBonRepository = typeBonRepository;
        }

        public async Task<IEnumerable<TypeBon>> GetAllTypeBonAsync()
        {
            return await _dbContext.TypeBon.ToListAsync();
        }

        public async Task<TypeBon> GetTypeBonByIdAsync(int code)
        {
            return await _dbContext.TypeBon.FirstOrDefaultAsync(u => u.Code == code);
        }

        public async Task<bool> AddTypeBonAsync(TypeBon typeBon)
        {
            await _typeBonRepository.AddEntity(typeBon);
            return true;
        }

        public async Task<bool> UpdateTypeBonAsync(int code, TypeBon typeBon)
        {
            var existingTypeBon = await _dbContext.TypeBon.FirstOrDefaultAsync(u => u.Code == code);

            if (existingTypeBon == null)
            {
                return false;
            }

            existingTypeBon.Libelle = typeBon.Libelle;

            await _typeBonRepository.UpdateEntity(existingTypeBon);
            return true;
        }

        public async Task<bool> DeleteTypeBonAsync(int code)
        {
            var existingTypeBon = await _dbContext.TypeBon.FirstOrDefaultAsync(u => u.Code == code);

            if (existingTypeBon == null)
            {
                return false;
            }

            await _typeBonRepository.DeleteEntity(code);
            return true;
        }
    }
}
