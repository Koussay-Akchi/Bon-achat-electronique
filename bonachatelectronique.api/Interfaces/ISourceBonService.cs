using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.Models;


namespace bonachatelectronique.api.Interfaces
{
    public interface ISourceBonService
    {
        Task<IEnumerable<SourceBon>> GetAllSourceBonAsync();
        Task<SourceBon> GetSourceBonByIdAsync(int code);
        Task<bool> AddSourceBonAsync(SourceBon SourceBon);
        Task<bool> UpdateSourceBonAsync(int code, SourceBon SourceBon);
        Task<bool> DeleteSourceBonAsync(int code);
    }
}
