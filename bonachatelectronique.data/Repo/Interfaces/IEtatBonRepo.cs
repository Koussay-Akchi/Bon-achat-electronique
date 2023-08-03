using bonachatelecronique.data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bonachatelecronique.data.Repo
{
    public interface IEtatBonRepo
    {
        Task<bool> AddEtatBonAsync(EtatBon EtatBon);
        Task<bool> DeleteEtatBonAsync(int id_EtatBon);
        Task<bool> UpdateEtatBonAsync(EtatBon EtatBon);
        Task<List<EtatBon>> GetAllEtatBonAsync();
        Task<EtatBon> GetEtatBonByIdAsync(int code);
    }
}
