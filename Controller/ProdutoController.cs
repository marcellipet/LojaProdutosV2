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
        public async Task<ActionResult<ResponseModel<PrdProduto>>> BuscarPorId(long id)
        {
            var produto = await _produtoInterface.BuscarPorId(id);
            return Ok(produto);
        }


        [HttpPost("Criar")]
        public async Task<ActionResult<ResponseModel<PrdProduto>>> Criar(PrdProduto produto)
        {
            var resposta = await _produtoInterface.Criar(produto);
            return Ok(resposta);
        }

        [HttpPut("{id}/Atualizar")]
        public async Task<ActionResult<ResponseModel<PrdProduto>>> Atualizar(long id,ProdutoAtualizarDto produtoAtualizar)
        {
            if(produtoAtualizar == null)  
            {
                return BadRequest("Produto não pode ser nulo.");
            }

            var resposta = await _produtoInterface.Atualizar(produtoAtualizar);
            return Ok(resposta);
        }

        [HttpDelete("Deletar/{id}")]
        public async Task<ActionResult<ResponseModel<bool>>> Deletar(long id)
        {
            var resposta = await _produtoInterface.Deletar(id);
            return Ok(resposta);
        }
    }
}
