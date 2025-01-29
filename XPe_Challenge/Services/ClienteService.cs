using XPe_Challenge.Models;
using XPe_Challenge.Repositories;

namespace XPe_Challenge.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<int> CountAsync()
        {
            return await _clienteRepository.CountAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Cliente>> GetByNameAsync(string nome)
        {
            return await _clienteRepository.GetByNameAsync(nome);
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "O objeto Cliente não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(cliente.Nome))
                throw new ArgumentException("Nome não pode ser vazio ou nulo.");

            if (string.IsNullOrWhiteSpace(cliente.CPF))
                throw new ArgumentException("CPF não pode ser vazio ou nulo.");

            if (cliente.CPF.Length != 11)
                throw new ArgumentException("CPF deve conter exatamente 11 dígitos.");

            if (string.IsNullOrWhiteSpace(cliente.Email))
                throw new ArgumentException("Email não pode ser vazio ou nulo.");

            return await _clienteRepository.CreateAsync(cliente);
        }

        public async Task<bool> UpdateAsync(int id, Cliente cliente)
        {
            if (id != cliente.Id)
                return false;

            var exists = await _clienteRepository.ExistsAsync(id);
            if (!exists)
                return false;

            await _clienteRepository.UpdateAsync(cliente);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exists = await _clienteRepository.ExistsAsync(id);
            if (!exists)
                return false;

            await _clienteRepository.DeleteAsync(id);
            return true;
        }
    }
}