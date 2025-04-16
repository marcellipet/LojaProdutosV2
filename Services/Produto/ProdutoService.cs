using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LojaProdutosV2.Services.Produto
{
    public class ProdutoService : IProdutoInterface
    {
        private readonly AppDbContext _context;
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<PrdProduto>>> Atualizar(ProdutoAtualizarDto produtoAtualizar)
        {
            ResponseModel<List<PrdProduto>> resposta = new ResponseModel<List<PrdProduto>>();

            try
            {
                var produtos = await _context.Produtos.FirstOrDefaultAsync(prdProduto => prdProduto.Id == produtoAtualizar.Id);
                if (produtos == null)
                {
                    resposta.Mensagem = "Produto não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }

                produtos.Nome = produtoAtualizar.Nome;
                produtos.Descricao = produtoAtualizar.Descricao;
                produtos.Preco = produtoAtualizar.Preco;
                produtos.Foto = produtoAtualizar.Foto;

                _context.Produtos.Update(produtos);
                await _context.SaveChangesAsync();

                resposta.Dados = new List<PrdProduto> { produtos };
                resposta.Mensagem = "Produto atualizado com sucesso.";
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
           ResponseModel<bool> resposta = new ResponseModel<bool>();
            try
            {
                var produtos = await _context.Produtos.FindAsync(Id);
                if (produtos == null)
                {
                    resposta.Mensagem = "Produto não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                _context.Produtos.Remove(produtos);
                await _context.SaveChangesAsync();
                resposta.Dados = true;
                resposta.Mensagem = "Produto deletado com sucesso.";
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
