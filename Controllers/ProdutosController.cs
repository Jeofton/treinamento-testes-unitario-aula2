using GestaoEstoque.Models;
using GestaoEstoque.Repositórios;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
    {
    private readonly IProdutoRepository _produtoRepository;

    public ProdutosController(IProdutoRepository produtoRepository)
        {
        _produtoRepository = produtoRepository;
        }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
        var produtos = await _produtoRepository.GetAllAsync();
        return Ok(produtos);
        }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(int id)
        {
        var produto = await _produtoRepository.GetByIdAsync(id);
        if(produto == null) return NotFound();

        return Ok(produto);
        }

    [HttpPost]
    public async Task<ActionResult<Produto>> AddProduto(Produto produto)
        {
        var novoProduto = await _produtoRepository.AddAsync(produto);
        return CreatedAtAction(nameof(GetProduto), new { id = novoProduto.Id }, novoProduto);
        }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduto(int id, Produto produto)
        {
        if(id != produto.Id) return BadRequest();

        var produtoExistente = await _produtoRepository.GetByIdAsync(id);
        if(produtoExistente == null) return NotFound();

        await _produtoRepository.UpdateAsync(produto);
        return NoContent();
        }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
        {
        var sucesso = await _produtoRepository.DeleteAsync(id);
        if(!sucesso) return NotFound();

        return NoContent();
        }
    }
