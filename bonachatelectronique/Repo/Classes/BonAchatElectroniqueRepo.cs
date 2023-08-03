using bonachatelectronique.Data;
using bonachatelectronique.Models;
using bonachatelectronique.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nest;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace bonachatelectronique.Repo
{
    public class BonAchatElectroniqueRepo : IBonAchatElectroniqueRepo

    {
        private readonly AppDbContext DbContext;
        bonachatelectronique.Data.IRepository<BonAchatElectronique> _BonAchatElectronique;
        public BonAchatElectroniqueRepo(AppDbContext dbContext, bonachatelectronique.Data.IRepository<BonAchatElectronique> BonAchatElectronique)
        {
            DbContext = dbContext;
            _BonAchatElectronique = BonAchatElectronique;
        }
        public async Task<bool> AddBonAchatElectroniqueAsync(BonAchatElectronique BonAchatElectronique)
        {
            try
            {

                await _BonAchatElectronique.AddEntity(BonAchatElectronique);
                return true;
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public async Task<bool> DeleteBonAchatElectroniqueAsync(int Code_BonAchatElectronique)
        {
            try
            {

                await _BonAchatElectronique.DeleteEntity(Code_BonAchatElectronique);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<BonAchatElectronique>> GetAllBonAchatElectroniqueAsync()
        {
            try
            {
                return await DbContext.BonAchatElectronique.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<BonAchatElectronique> GetBonAchatElectroniqueByIdAsync(int code)
        {
            try
            {
                var BonAchatElectronique = await DbContext.BonAchatElectronique.Where(u => (u.Id == code)).FirstOrDefaultAsync();
                return BonAchatElectronique;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateBonAchatElectroniqueAsync(BonAchatElectronique BonAchatElectronique)
        {
            try
            {
                await _BonAchatElectronique.UpdateEntity(BonAchatElectronique);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}