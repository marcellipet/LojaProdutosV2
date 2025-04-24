using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using LojaProdutosV2.Models.RequestResponse;
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
        public async Task<ActionResult> Registro([FromBody] UsrUsuario usrUsuario)
        {
            var registro = _authenticationInterface.Registro(usrUsuario.Email, usrUsuario.HashSenha, usrUsuario.Nome);
            return Ok(registro);
        }

        //[HttpPost("RefreshToken")]
        //public async Task<ActionResult> RefreshToken()
        //{
        //    var refreshToken = Request.Headers["RefreshToken"].ToString();
        //    var accessToken = Request.Headers["AccessToken"].ToString();
        //    var dateTime = DateTime.UtcNow;
        //    var token = _authenticationInterface.RefreshToken(refreshToken, dateTime);

        //    if (string.IsNullOrEmpty(token.Result.Dados.RefreshToken))
        //    {
        //        return BadRequest("Refresh token inválido.");
        //    }

        //    return Ok(token);
        //}

        [HttpPost("RefreshToken")]
        public async Task<ActionResult> ValidateAndGenerateToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            var token = await _authenticationInterface.ValidateAndGenerateToken(refreshTokenDto.Token, refreshTokenDto.HashRefresh);

            if (string.IsNullOrEmpty(token.Dados?.Token))
            {
                return BadRequest("RefreshToken inválido.");
            }
            return Ok(token);
        }
        

        [HttpGet("Me")]
        public async Task<ActionResult> Me()
        { 
            return NoContent();
        }
    }



}
