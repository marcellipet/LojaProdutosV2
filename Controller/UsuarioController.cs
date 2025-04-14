using LojaProdutos.Models;
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
    }
}
