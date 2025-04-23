using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models.RequestResponse;
using LojaProdutosV2.Services.Contato;
using LojaProdutosV2.Services.ContatoTipo;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutosV2.Controller
{
    [Route("ContatoTipos")]
    public class ContatoTipoController : ControllerBase
    {
        private readonly IContatoTipoInterface _contatoTipoInterface;

        public ContatoTipoController(IContatoTipoInterface contatoTipoInterface)
        {
            _contatoTipoInterface = contatoTipoInterface;
        }

        [HttpGet("ListarTodos")]
        public async Task<ActionResult<ResponseModel<List<CntContatoTipo>>>> ListarTodos()
        {
            var contatos = _contatoTipoInterface.ListarTodos();
            return Ok(contatos);
        }

        [HttpGet("{id}/BuscarPorId")]
        public async Task<ActionResult<ResponseModel<CntContatoTipo>>> BuscarPorId(long id)
        {
            var contato = _contatoTipoInterface.BuscarPorId(id);
            return Ok(contato);
        }

        [HttpPost("Criar")]
        public async Task<ActionResult<ResponseModel<CntContato>>> Criar([FromBody]CntContatoTipo contatoTipo)
        {
            if (contatoTipo == null)
            {
                return BadRequest("Contato não pode ser nulo.");
            }
            var resposta = _contatoTipoInterface.Criar(contatoTipo);
            return Ok(resposta);
        }

        [HttpPut("{id}/Atualizar")]
        public async Task<ActionResult<ResponseModel<CntContatoTipo>>> Atualizar(long id, [FromBody]ContatoTipoAtualizarDto contatoTipoAtualizar)
        {
            if (contatoTipoAtualizar == null)
            {
                return BadRequest("O tipo de Contato não pode ser nulo.");
            }
            var resposta = _contatoTipoInterface.Atualizar(contatoTipoAtualizar);
            return Ok(resposta);
        }

        [HttpDelete("{id}/Deletar")]
        public async Task<ActionResult<ResponseModel<bool>>> Deletar(long id)
        {
            var resposta = _contatoTipoInterface.Deletar(id);
            return Ok(resposta);
        }
    }
}
