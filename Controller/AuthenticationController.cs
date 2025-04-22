using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using LojaProdutosV2.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LojaProdutosV2.Controller
{
    [Route("Auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationInterface  _authenticationInterface;

        public AuthenticationController(IAuthenticationInterface authenticationInterface)
        {
            _authenticationInterface = authenticationInterface;
        }


        [HttpPost("Login")]
        public async Task<ActionResult> Logar([FromBody]LogarDto logarDto)
        {
           var autentic = _authenticationInterface.Logar(logarDto.Email, logarDto.Senha);
            return Ok(autentic);
        }

        [HttpPost("Registro")]
        public async Task<ResponseModel<ActionResult>> Registro([FromBody] UsrUsuario usrUsuario)
        {
            var resposta = _authenticationInterface.Registro(usrUsuario.Email, usrUsuario.HashSenha, usrUsuario.Nome);
            if (resposta.Status)
            {
                return Ok(resposta);
            }
            else
            {
                return BadRequest(resposta);
            }
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult> RefreshToken()
        {
            return NoContent();
        }

        [HttpGet("Me")]
        public async Task<ActionResult> Me()
        { 
            return NoContent();
        }
    }



}
