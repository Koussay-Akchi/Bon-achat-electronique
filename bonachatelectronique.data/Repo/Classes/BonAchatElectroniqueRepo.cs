using bonachatelecronique.data.Data;
using bonachatelecronique.data.Models;
using bonachatelecronique.data.Repo;
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

namespace bonachatelecronique.data.Repo
{
    class BonAchatElectroniqueRepo : IBonAchatElectroniqueRepo

    {
        private readonly AppDbContext DbContext;
        bonachatelecronique.data.Data.IRepository<BonAchatElectronique> _BonAchatElectronique;
        private Serilog.ILogger _Logger;
        public BonAchatElectroniqueRepo(AppDbContext dbContext, bonachatelecronique.data.Data.IRepository<BonAchatElectronique> BonAchatElectronique, Serilog.ILogger Logger)
        {
            DbContext = dbContext;
            _BonAchatElectronique = BonAchatElectronique;
            _Logger = Logger;
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
                _Logger.Error("Exception :" + ex);
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
                _Logger.Error("Exception :" + ex);
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
                _Logger.Error("Exception :" + ex);
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
                _Logger.Error("Exception :" + ex);
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
                _Logger.Error("Exception :" + ex);
                throw;
            }
        }
    }
}