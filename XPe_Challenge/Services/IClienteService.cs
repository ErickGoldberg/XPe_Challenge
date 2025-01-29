using XPe_Challenge.Models;

namespace XPe_Challenge.Services
{
    public interface IClienteService
    {
        Task<int> CountAsync();
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<IEnumerable<Cliente>> GetByNameAsync(string nome);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task<bool> UpdateAsync(int id, Cliente cliente);
        Task<bool> DeleteAsync(int id);
    }
}