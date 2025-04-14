using LojaProdutos.Models;
using LojaProdutosV2.Models;
using LojaProdutosV2.Services.Produto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutosV2.NovaPasta
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoInterface _produtoInterface;
        public ProdutoController(IProdutoInterface produtoInterface)
        {
            _produtoInterface = produtoInterface;
        }

        [HttpGet("ListarTodos")]
        public async Task<ActionResult<ResponseModel<List<PrdProduto>>>> ListarTodos()
        {
            var produtos = await _produtoInterface.ListarTodos();
            return Ok(produtos);
        }

        [HttpGet("BuscarPorId/{Id}")]
        public async Task<ActionResult<ResponseModel<PrdProduto>>> BuscarPorId(long Id)
        {
            var produto = await _produtoInterface.BuscarPorId(Id);
            return Ok(produto);
        }


        [HttpPost("Criar")]
        public async Task<ActionResult<ResponseModel<PrdProduto>>> Criar(PrdProduto produto)
        {
            var resposta = await _produtoInterface.Criar(produto);
            return Ok(resposta);
        }
    }
}
