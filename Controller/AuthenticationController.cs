using LojaProdutosV2.Dto;
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
        public async Task<ActionResult> Login([FromBody]LogarDto logarDto)
        {
           var autentic = _authenticationInterface.Logar(logarDto.Email, logarDto.Senha);
            return Ok(autentic);
        }

        [HttpPost("Registro")]
        public async Task<ActionResult> Registro()
        {
            return NoContent();
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
