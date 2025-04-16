using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;

namespace LojaProdutosV2.Services.Contato
{
    public interface IContatoInterface
    {
        Task<ResponseModel<List<CntContato>>> ListarTodos();
        Task<ResponseModel<CntContato>> BuscarPorId(long Id);
        Task<ResponseModel<CntContato>> Criar(CntContato contato);
        Task<ResponseModel<List<CntContato>>> Atualizar(ContatoAtualizarDto contatoAtualizar);
        Task<ResponseModel<bool>> Deletar(long Id);
    }
}
