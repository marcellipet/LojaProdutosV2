using LojaProdutos.Models;
using LojaProdutosV2.Dto;
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

        [HttpPut("Atualizar")]
        public async Task<ActionResult<ResponseModel<PrdProduto>>> Atualizar(long Id,ProdutoAtualizarDto produtoAtualizar)
        {
            if(produtoAtualizar == null)  
            {
                return BadRequest("Produto não pode ser nulo.");
            }

            var resposta = await _produtoInterface.Atualizar(produtoAtualizar);
            return Ok(resposta);
        }

        [HttpDelete("Deletar/{Id}")]
        public async Task<ActionResult<ResponseModel<bool>>> Deletar(long Id)
        {
            var resposta = await _produtoInterface.Deletar(Id);
            return Ok(resposta);
        }
    }
}
