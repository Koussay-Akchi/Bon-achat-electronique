using System;
using System.Threading.Tasks;
using System.Linq;
//using System.Data.Entity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using bonachatelecronique.data.Data;

namespace bonachatelecronique.dataS.Data
{

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
         protected AppDbContext RepoContext { get; set; }
         protected ILogger Logger;
        public Repository(AppDbContext dbContext, ILogger logger)
        {
            RepoContext = dbContext;
            Logger = logger;
        }
        public async Task<TEntity> GetEntity(object id)
        {
            try
            {
                var entity = await RepoContext.FindAsync<TEntity>(id);
                return entity;
            }
            catch(Exception)
            {
                 throw;
            }
        }

        public async Task<ICollection<TEntity>> GetAllEntity()
        {
            try
            {
                var entity = await RepoContext.Set<TEntity>().ToListAsync();
                return entity;
            }
            catch(Exception)
            {
                 throw;
            }
           
        }

        //public async Task<TEntity> AddEntity(TEntity entity)
        //{
        //    try
        //    {
        //        var result = await RepoContext.AddAsync<TEntity>(entity);
        //        await RepoContext.SaveChangesAsync();

        //        return result.Entity;
        //    }
        //    catch (Exception)
        //    {
        //         throw;
        //    }
        //}
        public async Task<bool> AddEntity(TEntity entity)
        {
            try
            {
                await RepoContext.AddAsync<TEntity>(entity);
                await RepoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex )
            {
                throw;
            }
        }
        public async Task<bool> AddListEntity(List<TEntity> list_entity)
        {
            try
            {
                RepoContext.AddRange(list_entity);
                await RepoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> UpdateEntity(TEntity entity)
        {
            try
            {
                RepoContext.Update<TEntity>(entity);
                await RepoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //public async Task<TEntity> UpdateEntity(TEntity entity)
        //{
        //    try
        //    {
        //        RepoContext.Update<TEntity>(entity);
        //        await RepoContext.SaveChangesAsync();
        //        return entity;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public async Task<bool> UpdateListEntity(List<TEntity> list_entity)
        {
            try
            {
                RepoContext.UpdateRange(list_entity);
                await RepoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<bool> DeleteEntity(object id)
        {
            try
            {
                var entity = await RepoContext.FindAsync<TEntity>(id);
                if (entity != null)
                {
                    RepoContext.Remove<TEntity>(entity);
                    await RepoContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new NullReferenceException("invalid id entity");
                }
            }
            catch (Exception)
            {
 
                throw;
            }
        }
        public async Task<bool> DeleteListEntity(List<TEntity> list_entity)
        {
            try
            {
                RepoContext.RemoveRange(list_entity);
                RepoContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
