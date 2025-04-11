using LojaProdutos.Models;
using LojaProdutosV2.Models;

namespace LojaProdutosV2.Services.Produto
{
    public interface IProdutoInterface 
    {
        Task<ResponseModel<List<PrdProduto>>> PegarTodos();
        Task<ResponseModel<PrdProduto>> BuscarPorId(long Id);
        Task<ResponseModel<PrdProduto>> Criar(PrdProduto produto);
        Task<ResponseModel<PrdProduto>> Atualizar(PrdProduto produto);
        Task<ResponseModel<bool>> Deletar(long Id);
    }
}
