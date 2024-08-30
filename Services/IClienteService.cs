using GestaoEstoque.Models;

namespace GestaoEstoque.Services
    {
    public interface IClienteService
        {
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente> CreateClienteAsync(Cliente cliente);
        Task<Cliente> UpdateClienteAsync(Cliente cliente);
        Task<bool> DeleteClienteAsync(int id);
        }
    }
