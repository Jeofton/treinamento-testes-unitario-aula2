using GestaoEstoque.Models;
using GestaoEstoque.Repositórios;

namespace GestaoEstoque.Services
    {
    public class ProdutoService : IProdutoService
        {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            {
            _produtoRepository = produtoRepository;
            }

        public async Task<IEnumerable<Produto>> GetAllAsync()
            {
            return await _produtoRepository.GetAllAsync();
            }

        public async Task<Produto> GetByIdAsync(int id)
            {
            return await _produtoRepository.GetByIdAsync(id);
            }

        public async Task<Produto> AddAsync(Produto produto)
            {
            return await _produtoRepository.AddAsync(produto);
            }

        public async Task<Produto> UpdateAsync(Produto produto)
            {
            return await _produtoRepository.UpdateAsync(produto);
            }

        public async Task<bool> DeleteAsync(int id)
            {
            return await _produtoRepository.DeleteAsync(id);
            }
        }
    }
