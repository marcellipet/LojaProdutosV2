using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models.RequestResponse;

namespace LojaProdutosV2.Services.ContatoTipo
{
    public interface IContatoTipoInterface
    {
        Task<ResponseModel<List<CntContatoTipo>>> ListarTodos();
        Task<ResponseModel<CntContatoTipo>> BuscarPorId(long id);
        Task<ResponseModel<CntContatoTipo>> Criar(CntContatoTipo contatoTipo);
        Task<ResponseModel<List<CntContatoTipo>>> Atualizar(ContatoTipoAtualizarDto contatoTipoAtualizar);
        Task<ResponseModel<bool>> Deletar(long id);
    }
}
