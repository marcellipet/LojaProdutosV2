using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;

namespace LojaProdutosV2.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsrUsuario>>> ListarUsuarios();
        Task<ResponseModel<UsrUsuario>> BuscarPorId(long Id);
        Task<ResponseModel<UsrUsuario>> Criar(UsrUsuario usuario);
        Task<ResponseModel<UsrUsuario>> Atualizar(UsuarioAtualizarDto usuarioAtualizar);
        Task<ResponseModel<bool>> Deletar(long Id);
    }
}
