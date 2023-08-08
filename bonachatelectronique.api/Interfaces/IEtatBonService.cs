using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.Models;


namespace bonachatelectronique.api.Interfaces
{
    public interface IEtatBonService
    {
        Task<IEnumerable<EtatBon>> GetAllEtatBonAsync();
        Task<EtatBon> GetEtatBonByIdAsync(int code);
        Task<bool> AddEtatBonAsync(EtatBon etatBon);
        Task<bool> UpdateEtatBonAsync(int code, EtatBon etatBon);
        Task<bool> DeleteEtatBonAsync(int code);
    }
}
