using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.Models;


namespace bonachatelectronique.api.Interfaces
{
    public interface IBonAchatElectroniqueService
    {
        Task<IEnumerable<BonAchatElectronique>> GetAllBonAchatElectroniqueAsync();
        Task<BonAchatElectronique> GetBonAchatElectroniqueByIdAsync(int code);
        Task<bool> AddBonAchatElectroniqueAsync(BonAchatElectronique BonAchatElectronique);
        Task<bool> UpdateBonAchatElectroniqueAsync(int code, BonAchatElectronique BonAchatElectronique);
        Task<bool> DeleteBonAchatElectroniqueAsync(int code);
    }
}
