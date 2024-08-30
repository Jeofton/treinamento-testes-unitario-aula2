using GestaoEstoque.Models;

namespace GestaoEstoque.Repositórios
    {
    public interface IProdutoRepository
        {
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(int id);
        Task<Produto> AddAsync(Produto produto);
        Task<Produto> UpdateAsync(Produto produto);
        Task<bool> DeleteAsync(int id);
        }
    }
