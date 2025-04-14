using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutosV2.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<UsrUsuario>> Atualizar(UsrUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UsrUsuario>> BuscarPorId(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UsrUsuario>> Criar(UsrUsuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> Deletar(long Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<UsrUsuario>>> ListarUsuarios()
        {
            ResponseModel<List<UsrUsuario>> resposta = new ResponseModel<List<UsrUsuario>>();
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();

                resposta.Dados = usuarios;
                resposta.Mensagem = "Lista de usuários obtida com sucesso.";

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
