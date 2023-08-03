using bonachatelecronique.data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bonachatelectronique.Repo
{
    public interface ISourceBonRepo
    {
        Task<bool> AddSourceBonAsync(SourceBon SourceBon);
        Task<bool> DeleteSourceBonAsync(int id_SourceBon);
        Task<bool> UpdateSourceBonAsync(SourceBon SourceBon);
        Task<List<SourceBon>> GetAllSourceBonAsync();
        Task<SourceBon> GetSourceBonByIdAsync(int code);
    }
}
