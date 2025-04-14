using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutosV2.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }
        public Task<ResponseModel<PrdProduto>> Atualizar(PrdProduto produto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<PrdProduto>> BuscarPorId(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<PrdProduto>> Criar(PrdProduto produto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> Deletar(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<PrdProduto>>> ListarTodos()
        {
            ResponseModel<List<PrdProduto>> resposta = new ResponseModel<List<PrdProduto>>();
            try
            {
                var produtos = await _context.Produtos.ToListAsync();
                resposta.Dados = produtos;
                resposta.Mensagem = "Lista de produtos obtida com sucesso.";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }
    }
}
