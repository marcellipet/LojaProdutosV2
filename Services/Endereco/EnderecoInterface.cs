using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models.RequestResponse;

namespace LojaProdutosV2.Services.Endereco
{
    public interface IEnderecoInterface
    {
        Task<ResponseModel<List<EndEndereco>>> ListarTodos();
        Task<ResponseModel<EndEndereco>> BuscarPorId(long id);
        Task<ResponseModel<EndEndereco>> BuscarPorIdUsuario(long id);
        Task<ResponseModel<EndEndereco>> Criar(EndEndereco endereco);
        Task<ResponseModel<List<EndEndereco>>> Atualizar(EnderecoAtualizarDto enderecoAtualizar);
        Task<ResponseModel<bool>> Deletar(long id);
    }
}
