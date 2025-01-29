using Microsoft.EntityFrameworkCore;
using XPe_Challenge.Data;
using XPe_Challenge.Models;

namespace XPe_Challenge.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly XPeDbContext _context;

        public ClienteRepository(XPeDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync()
        {
            return await _context.Clientes.CountAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetByNameAsync(string nome)
        {
            return await _context.Clientes
                .Where(c => c.Nome.Contains(nome))
                .ToListAsync();
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Clientes.AnyAsync(e => e.Id == id);
        }
    }
}