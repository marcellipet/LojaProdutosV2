using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;

namespace LojaProdutosV2.Services.Produto
{
    public interface IProdutoInterface 
    {
        Task<ResponseModel<List<PrdProduto>>> ListarTodos();
        Task<ResponseModel<PrdProduto>> BuscarPorId(long Id);
        Task<ResponseModel<PrdProduto>> Criar(PrdProduto produto);
        Task<ResponseModel<List<PrdProduto>>> Atualizar(ProdutoAtualizarDto produtoAtualizar);
        Task<ResponseModel<bool>> Deletar(long Id);
    }
}
