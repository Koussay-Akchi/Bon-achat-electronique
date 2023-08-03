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
    public class TypeBonRepo : ITypeBonRepo

    {
        private readonly AppDbContext DbContext;
        bonachatelectronique.Data.IRepository<TypeBon> _TypeBon;
        public TypeBonRepo(AppDbContext dbContext, bonachatelectronique.Data.IRepository<TypeBon> TypeBon)
        {
            DbContext = dbContext;
            _TypeBon = TypeBon;
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
                throw;
            }
        }
    }
}