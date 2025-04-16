using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;

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

        public Task<ResponseModel<List<EndEndereco>>> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
