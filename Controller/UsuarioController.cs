using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using LojaProdutosV2.Models.RequestResponse;
using LojaProdutosV2.Services.Jwt;
using LojaProdutosV2.Services.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutosV2.Controller
{
    [Route("Usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        private readonly IJwtManagerInterface _jwtManager;
        public UsuarioController(IJwtManagerInterface jwtManagerInterface ,IUsuarioInterface usuarioInterface)
        {
            _jwtManager = jwtManagerInterface;
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet("ListarUsuarios")]
        public async Task<ActionResult<ResponseModel<List<UsrUsuario>>>> ListarUsuarios()
        { 
            var usuarios = await _usuarioInterface.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}/BuscarPorId")]
        public async Task<ActionResult<ResponseModel<UsrUsuario>>> BuscarPorId(long id)
        {
            var usuario = await _usuarioInterface.BuscarPorId(id);
            return Ok(usuario);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("AutenticacaoUsuario")]
        public async Task<IActionResult> AuthenticateAsync([FromBody] UsrUsuario userLogin)
        {
            var validUser = await _usuarioInterface.IsValidUserAsync(userLogin);

            if (!validUser)
            {
                return Unauthorized();
            }

            var token = _jwtManager.GenerateToken(userLogin.Email);

            if (token == null)
            {
                return BadRequest("Error generating token");
            }

            RefreshToken obj = new RefreshToken();
            {
                obj.Nome= userLogin.Email;
                obj.UsrRefreshToken = _jwtManager.GenerateRefreshToken();
                obj.IsActive = true;
            }
            return Ok(new
            {
                Token = token,
                RefreshToken = obj.UsrRefreshToken,
                Expiracao = obj.Expiracao
            });
        }

            [HttpPut("Atualizar")]
            public async Task<ActionResult<ResponseModel<UsrUsuario>>> Atualizar(long id, [FromBody]UsuarioAtualizarDto usuarioAtualizar)
            {
            if (usuarioAtualizar == null)
            {
                return BadRequest("Usuário não pode ser nulo.");
            }
            var resposta = await _usuarioInterface.Atualizar(usuarioAtualizar);
            return Ok(resposta);
            }

            [HttpDelete("{id}/Deletar")]
            public async Task<ActionResult<ResponseModel<bool>>> Deletar(long id)
            {
            if (id <= 0)
            {
                return BadRequest("ID inválido.");
            }
            var resposta = _usuarioInterface.Deletar(id);
            if (resposta == null)
            {
                return NotFound("Usuário não encontrado.");
            }
            var Ok = await resposta;
            if (!Ok.Status)
            {
                return BadRequest(Ok.Mensagem);
            }
            return Ok;
            }

    }
}
