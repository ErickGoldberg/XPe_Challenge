using XPe_Challenge.Models;

namespace XPe_Challenge.Repositories
{
    public interface IClienteRepository
    {
        Task<int> CountAsync();
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<IEnumerable<Cliente>> GetByNameAsync(string nome);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}