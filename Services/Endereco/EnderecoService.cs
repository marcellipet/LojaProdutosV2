using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models.RequestResponse;
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
        public async Task<ResponseModel<List<EndEndereco>>> Atualizar(EnderecoAtualizarDto enderecoAtualizar)
        {
            ResponseModel<List<EndEndereco>> respota = new ResponseModel<List<EndEndereco>>();
            try
            {
                var endereco = await _context.Enderecos.FirstOrDefaultAsync(endereco => endereco.Id == enderecoAtualizar.Id);
                if (endereco == null)
                {
                    respota.Mensagem = "Endereço não encontrado.";
                    respota.Status = false;
                    return respota;
                }
                endereco.CEP = enderecoAtualizar.CEP;
                endereco.Logradouro = enderecoAtualizar.Logradouro;
                endereco.Numero = enderecoAtualizar.Numero;
                endereco.Bairro = enderecoAtualizar.Bairro;
                endereco.Cidade = enderecoAtualizar.Cidade;
                endereco.Estado = enderecoAtualizar.Estado;


                _context.Enderecos.Update(endereco);
                await _context.SaveChangesAsync();
                respota.Dados = new List<EndEndereco> { endereco };
                respota.Mensagem = "Endereço atualizado com sucesso.";
                respota.Status = true;
                return respota;
            }
            catch (Exception ex)
            {
                respota.Mensagem = ex.Message;
                respota.Status = false;
                return respota;
            }
        }

        public async Task<ResponseModel<EndEndereco>> BuscarPorId(long id)
        {
            ResponseModel<EndEndereco> responseModel = new ResponseModel<EndEndereco>();
            try
            {
                var endereco = await _context.Enderecos.FirstOrDefaultAsync(endereco => endereco.Id == id);
                if (endereco == null)
                {
                    responseModel.Mensagem = "Endereço não encontrado.";
                    responseModel.Status = false;
                    return responseModel;
                }
                responseModel.Dados = endereco;
                responseModel.Mensagem = "Endereço encontrado com sucesso.";
                responseModel.Status = true;
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Mensagem = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<EndEndereco>> BuscarPorIdUsuario(long id)
        {
            ResponseModel<EndEndereco> resposta = new ResponseModel<EndEndereco>();
            try
            {
                var endereco = await _context.Enderecos.FirstOrDefaultAsync(endereco => endereco.IdUsuario.Id == id);
                if (endereco == null)
                {
                    resposta.Mensagem = "Endereço não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = endereco;
                resposta.Mensagem = "Endereço encontrado com sucesso.";
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

        public async Task<ResponseModel<EndEndereco>> Criar(EndEndereco endereco)
        {
            ResponseModel<EndEndereco> resposta = new ResponseModel<EndEndereco>();
            try
            {
                if (endereco == null)
                {
                    resposta.Mensagem = "Endereço não pode ser nulo.";
                    resposta.Status = false;
                    return resposta;
                }
                await _context.Enderecos.AddAsync(endereco);
                await _context.SaveChangesAsync();
                resposta.Dados = endereco;
                resposta.Mensagem = "Endereço criado com sucesso.";
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

        public async Task<ResponseModel<bool>> Deletar(long id)
        {
            ResponseModel<bool> resposta = new ResponseModel<bool>();
            try
            {
                var endereco = await _context.Enderecos.FindAsync(id);
                if (endereco == null)
                {
                    resposta.Mensagem = "Endereço não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                _context.Enderecos.Remove(endereco);
                await _context.SaveChangesAsync();
                resposta.Dados = true;
                resposta.Mensagem = "Endereço deletado com sucesso.";
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
