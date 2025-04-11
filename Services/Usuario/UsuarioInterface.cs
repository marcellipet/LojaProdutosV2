using LojaProdutos.Models;
using LojaProdutosV2.Models;

namespace LojaProdutosV2.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsrUsuario>>> PegarTodos();
        Task<ResponseModel<UsrUsuario>> BuscarPorId(int id);
        Task<ResponseModel<UsrUsuario>> Criar(UsrUsuario produto);
        Task<ResponseModel<UsrUsuario>> Atualizar(UsrUsuario produto);
        Task<ResponseModel<bool>> Deletar(int id);
    }
}
