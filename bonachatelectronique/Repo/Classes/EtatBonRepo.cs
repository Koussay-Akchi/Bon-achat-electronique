using bonachatelectronique.Data;
using bonachatelectronique.Models;
using bonachatelectronique.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace bonachatelectronique.Repo
{
    public class EtatBonRepo : IEtatBonRepo

    {
        private readonly AppDbContext DbContext;
        bonachatelectronique.Data.IRepository<EtatBon> _EtatBon;

        public EtatBonRepo(AppDbContext dbContext, bonachatelectronique.Data.IRepository<EtatBon> EtatBon)
        {
            DbContext = dbContext;
            _EtatBon = EtatBon;
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
                throw;
            }
        }
    }
}