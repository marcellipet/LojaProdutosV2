using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutosV2.Services.Endereco
{
    public class EnderecoService : IEnderecoInterface
    {
        private readonly AppDbContext _context;
        public EnderecoService(AppDbContext context)
        {
            _context = context;
        }
        public Task<ResponseModel<List<EndEndereco>>> Atualizar(EnderecoAtualizarDto enderecoAtualizar)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<EndEndereco>> BuscarPorId(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<EndEndereco>> BuscarPorIdUsuario(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<EndEndereco>> Criar(EndEndereco endereco)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> Deletar(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<EndEndereco>>> ListarTodos()
        {
            ResponseModel<List<EndEndereco>> resposta = new ResponseModel<List<EndEndereco>>();
            try
            {
                var enderecos = await _context.Enderecos.ToListAsync();
                if (enderecos == null || !enderecos.Any())
                {
                    resposta.Mensagem = "Nenhum endereço encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = enderecos;
                resposta.Mensagem = "Endereços encontrados com sucesso.";
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
