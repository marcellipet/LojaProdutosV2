using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models.RequestResponse;

namespace LojaProdutosV2.Services.Contato
{
    public interface IContatoInterface
    {
        Task<ResponseModel<List<CntContato>>> ListarTodos();
        Task<ResponseModel<CntContato>> BuscarPorId(long id);
        Task<ResponseModel<CntContato>> Criar(CntContato contato);
        Task<ResponseModel<List<CntContato>>> Atualizar(ContatoAtualizarDto contatoAtualizar);
        Task<ResponseModel<bool>> Deletar(long id);
    }
}
