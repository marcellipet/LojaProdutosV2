using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutosV2.Services.ContatoTipo
{
    public class ContatoTipoService : IContatoTipoInterface
    {
        private readonly AppDbContext _context;
        public ContatoTipoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<CntContatoTipo>>> Atualizar(ContatoTipoAtualizarDto contatoTipoAtualizar)
        {
            ResponseModel<List<CntContatoTipo>> resposta = new ResponseModel<List<CntContatoTipo>>();

            try
            {
                var contatoTipos = await _context.ContatoTipos.FirstOrDefaultAsync(cntContatoTipo => cntContatoTipo.Id == contatoTipoAtualizar.Id);
                if (contatoTipos == null)
                {
                    resposta.Mensagem = "Contato não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }

                contatoTipos.Nome = contatoTipoAtualizar.Nome;
                contatoTipos.Descricao = contatoTipoAtualizar.Descricao;
                _context.ContatoTipos.Update(contatoTipos);

                await _context.SaveChangesAsync();

                resposta.Dados = new List<CntContatoTipo> { contatoTipos };
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

        public async Task<ResponseModel<CntContatoTipo>> BuscarPorId(long Id)
        {
            ResponseModel<CntContatoTipo> resposta = new ResponseModel<CntContatoTipo>();
            try
            {
                CntContatoTipo contatoTipo = _context.ContatoTipos.FirstOrDefault(x => x.Id == Id);
                if (contatoTipo == null)
                {
                    resposta.Mensagem = "Contato tipo não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = contatoTipo;
                resposta.Mensagem = "Contato tipo encontrado com sucesso.";
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

        public async Task<ResponseModel<CntContatoTipo>> Criar(CntContatoTipo contatoTipo)
        {
            ResponseModel<CntContatoTipo> resposta = new ResponseModel<CntContatoTipo>();
            try
            {
                if (contatoTipo == null)
                {
                    resposta.Mensagem = "Contato tipo não pode ser nulo.";
                    resposta.Status = false;
                    return resposta;
                }
                await _context.ContatoTipos.AddAsync(contatoTipo);
                await _context.SaveChangesAsync();
                resposta.Dados = contatoTipo;
                resposta.Mensagem = "Contato tipo criado com sucesso.";
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
                resposta.Dados = true;
                resposta.Mensagem = "Contato tipo deletado com sucesso.";
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

        public async Task<ResponseModel<List<CntContatoTipo>>> ListarTodos()
        {
            ResponseModel<List<CntContatoTipo>> resposta = new ResponseModel<List<CntContatoTipo>>();

            try
            {
                List<CntContatoTipo> contatoTipos = new List<CntContatoTipo>();
                resposta.Dados = contatoTipos;
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
