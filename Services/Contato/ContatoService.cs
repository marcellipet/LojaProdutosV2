using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutosV2.Services.Contato
{
    public class ContatoService : IContatoInterface
    {
        private readonly AppDbContext _context;
        public ContatoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<CntContato>>> Atualizar(ContatoAtualizarDto contatoAtualizar)
        {
            ResponseModel<List<CntContato>> resposta = new ResponseModel<List<CntContato>>();

            try
            {
                var contatos = await _context.Contatos.FirstOrDefaultAsync(cntContato => cntContato.Id == contatoAtualizar.Id);
                if (contatos == null)
                {
                    resposta.Mensagem = "Contato não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }

                contatos.NumeroTelefone = contatoAtualizar.NumeroTelefone;
                _context.Contatos.Update(contatos);

                await _context.SaveChangesAsync();

                resposta.Dados = new List<CntContato> { contatos };
                resposta.Mensagem = "Contato atualizado com sucesso.";
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

        public  async Task<ResponseModel<CntContato>> BuscarPorId(long Id)
        {
            ResponseModel<CntContato> resposta = new ResponseModel<CntContato>();
            try
            {
                var contato = _context.Contatos.FirstOrDefaultAsync(cntContato => cntContato.Id == Id);
                if (contato == null)
                {
                    resposta.Mensagem = "Contato não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = contato.Result;
                resposta.Mensagem = "Contato encontrado com sucesso.";
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

        public async Task<ResponseModel<CntContato>> Criar(CntContato contato)
        {
            ResponseModel<CntContato> resposta = new ResponseModel<CntContato>();
            try
            {
                await _context.Contatos.AddAsync(contato);
                await _context.SaveChangesAsync();
                resposta.Dados = contato;
                resposta.Mensagem = "Contato criado com sucesso.";
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
                var contato = _context.Contatos.FirstOrDefaultAsync(cntContato => cntContato.Id == Id);
                if (contato == null)
                {
                    resposta.Mensagem = "Contato não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                _context.Contatos.Remove(contato.Result);
                _context.SaveChanges();

                resposta.Dados = true;
                resposta.Mensagem = "Contato deletado com sucesso.";
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

        public async Task<ResponseModel<List<CntContato>>> ListarTodos()
        {
            ResponseModel<List<CntContato>> resposta = new ResponseModel<List<CntContato>>();

            try
            {
                List<CntContato> contato = new List<CntContato>();
                resposta.Dados = contato;
                resposta.Mensagem = "Lista de contatos tipos retornada com sucesso.";
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
