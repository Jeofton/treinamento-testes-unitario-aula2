using GestaoEstoque.Models;
using GestaoEstoque.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEstoque.Controllers
    {
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
        {
        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
            {
            _produtoService = produtoService;
            }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
            {
            var produtos = await _produtoService.GetAllAsync();
            return Ok(produtos);
            }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
            {
            var produto = await _produtoService.GetByIdAsync(id);
            if(produto == null)
                {
                return NotFound();
                }
            return Ok(produto);
            }

        [HttpPost]
        public async Task<ActionResult<Produto>> AddProduto(Produto produto)
            {
            var novoProduto = await _produtoService.AddAsync(produto);
            return CreatedAtAction(nameof(GetProduto), new { id = novoProduto.Id }, novoProduto);
            }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, Produto produto)
            {
            if(id != produto.Id)
                {
                return BadRequest();
                }

            var produtoAtualizado = await _produtoService.UpdateAsync(produto);
            if(produtoAtualizado == null)
                {
                return NotFound();
                }

            return NoContent();
            }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
            {
            var deleted = await _produtoService.DeleteAsync(id);
            if(!deleted)
                {
                return NotFound();
                }

            return NoContent();
            }
        }
    }
