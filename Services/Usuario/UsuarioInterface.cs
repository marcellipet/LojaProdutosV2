using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models.RequestResponse;

namespace LojaProdutosV2.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsrUsuario>>> ListarUsuarios();
        Task<ResponseModel<UsrUsuario>> BuscarPorId(long id);
        Task<ResponseModel<UsrUsuario>> Criar(UsrUsuario usuario);
        Task<ResponseModel<List<UsrUsuario>>> Atualizar(UsuarioAtualizarDto usuarioAtualizar);
        Task<ResponseModel<bool>> Deletar(long id);

        //Task<bool> IsValidUserAsync(UsrUserLogin users);
        //UsrRefreshToken AddUserRefreshTokens(UsrRefreshToken usrRefreshToken);
        //UsrRefreshToken GetSavedRefreshToken(string username, string refreshtoken);
        //void DeleteUserRefreshToken(string username, string refreshToken);
    }
}
