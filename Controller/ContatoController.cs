using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using LojaProdutosV2.Services.Contato;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutosV2.Controller
{
    [Route("Contatos")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoInterface _contatoInterface;
        public ContatoController(IContatoInterface contatoInterface)
        {
            _contatoInterface = contatoInterface;
        }

        [HttpGet("ListarTodos")]
        public async Task<ActionResult<ResponseModel<List<CntContato>>>> ListarTodos()
        {
            var contatos = _contatoInterface.ListarTodos();
            return Ok(contatos);
        }

        [HttpGet("{id}/BuscarPorId")]
        public async Task<ActionResult<ResponseModel<CntContato>>> BuscarPorId(long id)
        {
            var contato = _contatoInterface.BuscarPorId(id);
            return Ok(contato);
        }

        [HttpPost("Criar")]
        public async Task<ActionResult<ResponseModel<CntContato>>> Criar([FromBody]CntContato contato)
        {
            if (contato == null)
            {
                return BadRequest("Contato não pode ser nulo.");
            }
            var resposta = _contatoInterface.Criar(contato);
            return Ok(resposta);
        }

        [HttpPut("{id}/Atualizar")]
        public async Task<ActionResult<ResponseModel<CntContato>>> Atualizar(long id, [FromBody]ContatoAtualizarDto contatoAtualizar)
        {
            if (contatoAtualizar == null)
            {
                return BadRequest("Contato não pode ser nulo.");
            }
            var resposta = _contatoInterface.Atualizar(contatoAtualizar);
            return Ok(resposta);
        }

        [HttpDelete("{id}/Deletar")]
        public async Task<ActionResult<ResponseModel<bool>>> Deletar(long id)
        {
            var resposta = _contatoInterface.Deletar(id);
            return Ok(resposta);
        }
    }
}
