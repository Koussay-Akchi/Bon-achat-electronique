using bonachatelecronique.data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bonachatelecronique.data.Repo
{
    public interface IBonAchatElectroniqueRepo
    {
        Task<bool> AddBonAchatElectroniqueAsync(BonAchatElectronique BonAchatElectronique);
        Task<bool> DeleteBonAchatElectroniqueAsync(int id_BonAchatElectronique);
        Task<bool> UpdateBonAchatElectroniqueAsync(BonAchatElectronique BonAchatElectronique);
        Task<List<BonAchatElectronique>> GetAllBonAchatElectroniqueAsync();
        Task<BonAchatElectronique> GetBonAchatElectroniqueByIdAsync(int code);
    }
}
