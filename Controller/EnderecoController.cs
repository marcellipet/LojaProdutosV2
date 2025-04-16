using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using LojaProdutosV2.Services.Endereco;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutosV2.Controller
{
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoInterface _enderecoInterface;
        public EnderecoController(IEnderecoInterface enderecoInterface)
        {
            _enderecoInterface = enderecoInterface;
        }
        [HttpGet("ListarTodos")]
        public async Task<ActionResult<ResponseModel<List<EndEndereco>>>> ListarTodos()
        {
            var enderecos = _enderecoInterface.ListarTodos();
            return Ok(enderecos);
        }
        [HttpGet("{id}/BuscarPorId")]
        public async Task<ActionResult<ResponseModel<EndEndereco>>> BuscarPorId(long id)
        {
            var endereco = _enderecoInterface.BuscarPorId(id);
            return Ok(endereco);
        }
        [HttpPost("Criar")]
        public async Task<ActionResult<ResponseModel<EndEndereco>>> Criar([FromBody] EndEndereco endereco)
        {
            if (endereco == null)
            {
                return BadRequest("O endereço não pode ser nulo.");
            }
            var resposta = _enderecoInterface.Criar(endereco);
            return Ok(resposta);
        }
        [HttpPut("{id}/Atualizar")]
        public async Task<ActionResult<ResponseModel<EndEndereco>>> Atualizar(long id, [FromBody] EnderecoAtualizarDto enderecoAtualizar)
        {
            if (enderecoAtualizar == null)
            {
                return BadRequest("O endereço não pode ser nulo.");
            }
            var resposta = _enderecoInterface.Atualizar(enderecoAtualizar);
            return Ok(resposta);
        }
        [HttpDelete("{id}/Deletar")]
        public async Task<ActionResult<ResponseModel<bool>>> Deletar(long id)
        {
            var resposta = _enderecoInterface.Deletar(id);
            return Ok(resposta);
        }
    }
}
