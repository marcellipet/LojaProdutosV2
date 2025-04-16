using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using LojaProdutosV2.Services.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutosV2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<ResponseModel<List<UsrUsuario>>>> ListarUsuarios()
        { 
            var usuarios = await _usuarioInterface.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("BuscarPorId/{id}")]
        public async Task<ActionResult<ResponseModel<UsrUsuario>>> BuscarPorId(long id)
        {
            var usuario = await _usuarioInterface.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost("Criar")]
        public async Task<ActionResult<ResponseModel<UsrUsuario>>> Criar(UsrUsuario usuario)
        {
            var resposta = await _usuarioInterface.Criar(usuario);
            return Ok(resposta);
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult<ResponseModel<UsrUsuario>>> Atualizar(long id, UsuarioAtualizarDto usuarioAtualizar)
        {
            if (usuarioAtualizar == null)
            {
                return BadRequest("Usuário não pode ser nulo.");
            }
            var resposta = await _usuarioInterface.Atualizar(usuarioAtualizar);
            return Ok(resposta);
        }

        [HttpDelete("Deletar/{id}")]
        public ActionResult<ResponseModel<bool>> Deletar(long id)
        {
            var resposta = _usuarioInterface.Deletar(id);
            return Ok(resposta);
        }

    }
}
