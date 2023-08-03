using bonachatelecronique.data.Data;
using bonachatelecronique.data.Models;
using bonachatelecronique.data.Repo;
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

namespace bonachatelecronique.data.Repo
{
    class TypeBonRepo : ITypeBonRepo

    {
        private readonly AppDbContext DbContext;
        bonachatelecronique.data.Data.IRepository<TypeBon> _TypeBon;
        private Serilog.ILogger _Logger;
        public TypeBonRepo(AppDbContext dbContext, bonachatelecronique.data.Data.IRepository<TypeBon> TypeBon, Serilog.ILogger Logger)
        {
            DbContext = dbContext;
            _TypeBon = TypeBon;
            _Logger = Logger;
        }
        public async Task<bool> AddTypeBonAsync(TypeBon TypeBon)
        {
            try
            {

                await _TypeBon.AddEntity(TypeBon);
                return true;
            }
            catch (Exception ex)
            {
                _Logger.Error("Exception :" + ex);
                throw;

            }
        }

        public async Task<bool> DeleteTypeBonAsync(int Code_TypeBon)
        {
            try
            {

                await _TypeBon.DeleteEntity(Code_TypeBon);
                return true;
            }
            catch (Exception ex)
            {
                _Logger.Error("Exception :" + ex);
                throw;
            }
        }

        public async Task<List<TypeBon>> GetAllTypeBonAsync()
        {
            try
            {
                return await DbContext.TypeBon.ToListAsync();
            }
            catch (Exception ex)
            {
                _Logger.Error("Exception :" + ex);
                throw;
            }
        }

        public async Task<TypeBon> GetTypeBonByIdAsync(int code)
        {
            try
            {
                var TypeBon = await DbContext.TypeBon.Where(u => (u.Code == code)).FirstOrDefaultAsync();
                return TypeBon;
            }
            catch (Exception ex)
            {
                _Logger.Error("Exception :" + ex);
                throw;
            }
        }

        public async Task<bool> UpdateTypeBonAsync(TypeBon TypeBon)
        {
            try
            {
                await _TypeBon.UpdateEntity(TypeBon);
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