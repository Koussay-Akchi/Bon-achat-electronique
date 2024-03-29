﻿using bonachatelectronique.Data;
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
    public class SourceBonRepo : ISourceBonRepo

    {
        private readonly AppDbContext DbContext;
        bonachatelectronique.Data.IRepository<SourceBon> _SourceBon;
        public SourceBonRepo(AppDbContext dbContext, bonachatelectronique.Data.IRepository<SourceBon> SourceBon)
        {
            DbContext = dbContext;
            _SourceBon = SourceBon;
        }
        public async Task<bool> AddSourceBonAsync(SourceBon SourceBon)
        {
            try
            {

                await _SourceBon.AddEntity(SourceBon);
                return true;
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public async Task<bool> DeleteSourceBonAsync(int Code_SourceBon)
        {
            try
            {

                await _SourceBon.DeleteEntity(Code_SourceBon);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<SourceBon>> GetAllSourceBonAsync()
        {
            try
            {
                return await DbContext.SourceBon.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SourceBon> GetSourceBonByIdAsync(int code)
        {
            try
            {
                var SourceBon = await DbContext.SourceBon.Where(u => (u.Code == code)).FirstOrDefaultAsync();
                return SourceBon;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateSourceBonAsync(SourceBon SourceBon)
        {
            try
            {
                await _SourceBon.UpdateEntity(SourceBon);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}