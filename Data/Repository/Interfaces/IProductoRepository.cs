using System.Collections.Generic;
using System.Threading.Tasks;
using MiPrimerAppMVC.Models;

namespace MiPrimerAppMVC.Data.Repository.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> GetAllAsync();
        Task<Producto> GetByIdAsync(int id);
        Task CreateAsync(Producto producto);
        Task UpdateAsync(Producto producto);
        Task<bool> DeleteAsync(int id);
    }
}