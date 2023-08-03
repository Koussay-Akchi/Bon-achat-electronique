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
    class EtatBonRepo : IEtatBonRepo

    {
        private readonly AppDbContext DbContext;
        bonachatelecronique.data.Data.IRepository<EtatBon> _EtatBon;
        private Serilog.ILogger _Logger;
        public EtatBonRepo(AppDbContext dbContext, bonachatelecronique.data.Data.IRepository<EtatBon> EtatBon, Serilog.ILogger Logger)
        {
            DbContext = dbContext;
            _EtatBon = EtatBon;
            _Logger = Logger;
        }
        public async Task<bool> AddEtatBonAsync(EtatBon EtatBon)
        {
            try
            {

                await _EtatBon.AddEntity(EtatBon);
                return true;
            }
            catch (Exception ex)
            {
                _Logger.Error("Exception :" + ex);
                throw;

            }
        }

        public async Task<bool> DeleteEtatBonAsync(int Code_EtatBon)
        {
            try
            {

                await _EtatBon.DeleteEntity(Code_EtatBon);
                return true;
            }
            catch (Exception ex)
            {
                _Logger.Error("Exception :" + ex);
                throw;
            }
        }

        public async Task<List<EtatBon>> GetAllEtatBonAsync()
        {
            try
            {
                return await DbContext.EtatBon.ToListAsync();
            }
            catch (Exception ex)
            {
                _Logger.Error("Exception :" + ex);
                throw;
            }
        }

        public async Task<EtatBon> GetEtatBonByIdAsync(int code)
        {
            try
            {
                var EtatBon = await DbContext.EtatBon.Where(u => (u.Code == code)).FirstOrDefaultAsync();
                return EtatBon;
            }
            catch (Exception ex)
            {
                _Logger.Error("Exception :" + ex);
                throw;
            }
        }

        public async Task<bool> UpdateEtatBonAsync(EtatBon EtatBon)
        {
            try
            {
                await _EtatBon.UpdateEntity(EtatBon);
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