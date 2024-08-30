using GestaoEstoque.Data;
using GestaoEstoque.Models;
using GestaoEstoque.Repositórios;
using Microsoft.EntityFrameworkCore;

namespace GestaoEstoque.Repositories
    {
    public class ProdutoRepository : IProdutoRepository
        {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
            {
            _context = context;
            }

        public async Task<IEnumerable<Produto>> GetAllAsync()
            {
            return await _context.Produtos.ToListAsync();
            }

        public async Task<Produto> GetByIdAsync(int id)
            {
            return await _context.Produtos.FindAsync(id);
            }

        public async Task<Produto> AddAsync(Produto produto)
            {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
            }

        public async Task<Produto> UpdateAsync(Produto produto)
            {
            if(await _context.Produtos.AnyAsync(p => p.Id == produto.Id))
                {
                _context.Entry(produto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return produto;
                }

            return null;
            }

        public async Task<bool> DeleteAsync(int id)
            {
            var produto = await _context.Produtos.FindAsync(id);
            if(produto == null)
                {
                return false;
                }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return true;
            }
        }
    }
