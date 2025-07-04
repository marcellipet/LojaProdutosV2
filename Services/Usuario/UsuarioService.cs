using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using LojaProdutosV2.Models.RequestResponse;
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

        public async Task<ResponseModel<List<UsrUsuario>>> Atualizar(UsuarioAtualizarDto usuarioAtualizar)
        {
            ResponseModel<List<UsrUsuario>> resposta = new ResponseModel<List<UsrUsuario>>();

            try
            {
                var usuarios = await _context.Usuarios.FirstOrDefaultAsync(usrUsuario => usrUsuario.Id == usuarioAtualizar.Id);
                if (usuarios == null)
                {
                    resposta.Mensagem = "Usuário não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                usuarios.Nome = usuarioAtualizar.Nome;
                usuarios.Email = usuarioAtualizar.Email;

                _context.Usuarios.Update(usuarios);
                await _context.SaveChangesAsync();

                resposta.Dados = new List<UsrUsuario> { usuarios };
                resposta.Mensagem = "Usuário atualizado com sucesso.";
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
        public async Task<ResponseModel<UsrUsuario>> BuscarPorId(long id)
        {
            ResponseModel<UsrUsuario> resposta = new ResponseModel<UsrUsuario>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usrUsuario => usrUsuario.Id == id);
                if (usuario == null)
                {
                    resposta.Mensagem = "Usuário não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = usuario;
                resposta.Mensagem = "Usuário encontrado com sucesso.";
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
        public async Task<ResponseModel<UsrUsuario>> Criar(UsrUsuario usuario)
        {
            ResponseModel<UsrUsuario> resposta = new ResponseModel<UsrUsuario>();

            try
            {
                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();
                resposta.Dados = usuario;
                resposta.Mensagem = "Usuário criado com sucesso.";
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
                var usuarios = await _context.Produtos.FindAsync(id);
                if (usuarios == null)
                {
                    resposta.Mensagem = "Produto não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                _context.Produtos.Remove(usuarios);
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
        //     public UsrRefreshToken AddUserRefreshTokens(UsrRefreshToken usrRefreshToken)
        //{
        //    _context.UserRefreshToken.Add(usrRefreshToken);
        //    _context.SaveChanges();
        //    return usrRefreshToken;
        //}

        //public void DeleteUserRefreshToken(string username, string refreshToken)
        //{
        //    var item = _context.UserRefreshToken.FirstOrDefault(u => u.UsrName == username && u.RefreshToken == refreshToken);
        //    if (item != null)
        //    {
        //        _context.UserRefreshToken.Remove(item);
        //        _context.SaveChanges();
        //    }
        //}

        public RefreshToken GetSavedRefreshToken(string username, string refreshtoken)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(refreshtoken))
            {
                throw new ArgumentException("Username and refresh token cannot be null or empty.");
            }
            return _context.RefreshTokens.FirstOrDefault(u => u.Nome == username && u.UsrRefreshToken == refreshtoken && u.IsActive == true);
        }

        public async Task<bool> IsValidUserAsync(UsrUsuario users)
        {
            var user =  _context.Usuarios.FirstOrDefault(u => u.Nome == users.Nome && u.HashSenha == users.HashSenha);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
    }
}
