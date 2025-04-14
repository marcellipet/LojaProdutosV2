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

        public async Task<ResponseModel<PrdProduto>> BuscarPorId(long Id)
        {
            ResponseModel<PrdProduto> resposta = new ResponseModel<PrdProduto>();
            try
            {
                var produtos = _context.Produtos.FirstOrDefaultAsync(prdProduto => prdProduto.Id == Id);

                if (produtos == null)
                {
                    resposta.Mensagem = "Produto não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = await produtos;
                resposta.Mensagem = "Produto encontrado com sucesso.";
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

        public async Task<ResponseModel<PrdProduto>> Criar(PrdProduto produto)
        {
            ResponseModel<PrdProduto> resposta = new ResponseModel<PrdProduto>();

            try
            {
                var produtos = new PrdProduto
                {
                    Nome = produto.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    Foto = produto.Foto
                };

                _context.Add(produtos);
                await _context.SaveChangesAsync();

                resposta.Dados = produtos;
                resposta.Mensagem = "Produto criado com sucesso.";
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

        public async Task<ResponseModel<bool>> Deletar(long Id)
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
