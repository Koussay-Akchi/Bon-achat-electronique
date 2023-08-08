using System.Collections.Generic;
using System.Threading.Tasks;
using bonachatelectronique.Models;


namespace bonachatelectronique.api.Interfaces
{
    public interface ITypeBonService
    {
        Task<IEnumerable<TypeBon>> GetAllTypeBonAsync();
        Task<TypeBon> GetTypeBonByIdAsync(int code);
        Task<bool> AddTypeBonAsync(TypeBon TypeBon);
        Task<bool> UpdateTypeBonAsync(int code, TypeBon TypeBon);
        Task<bool> DeleteTypeBonAsync(int code);
    }
}
