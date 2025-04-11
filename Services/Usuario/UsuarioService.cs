using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Models;

namespace LojaProdutosV2.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<UsrUsuario>> Atualizar(UsrUsuario produto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UsrUsuario>> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UsrUsuario>> Criar(UsrUsuario produto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<bool>> Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UsrUsuario>>> PegarTodos()
        {
            try
            {

            }
            catch (Exception ex) { 
            
            }
        }
    }
}
