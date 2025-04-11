using LojaProdutos.Models;
using LojaProdutosV2.Models;

namespace LojaProdutosV2.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        public Task<ResponseModel<PrdProduto>> Atualizar(PrdProduto produto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<PrdProduto>> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<PrdProduto>> Criar(PrdProduto produto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<PrdProduto>>> PegarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
