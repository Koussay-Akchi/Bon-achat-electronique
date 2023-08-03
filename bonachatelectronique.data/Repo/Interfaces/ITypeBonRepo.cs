using bonachatelecronique.data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace bonachatelectronique.Repo
{
    public interface ITypeBonRepo
    {
        Task<bool> AddTypeBonAsync(TypeBon TypeBon);
        Task<bool> DeleteTypeBonAsync(int id_TypeBon);
        Task<bool> UpdateTypeBonAsync(TypeBon TypeBon);
        Task<List<TypeBon>> GetAllTypeBonAsync();
        Task<TypeBon> GetTypeBonByIdAsync(int code);
    }
}
