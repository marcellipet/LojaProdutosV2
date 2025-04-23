using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models.RequestResponse;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace LojaProdutosV2.Services.Authentication
{
    public class AuthenticationService : IAuthenticationInterface
    {
        private readonly AppDbContext _context;
        public AuthenticationService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<LoginDto>> AccesToken(string accessToken, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<LoginDto>> Logar(string email, string senha)
        {
            ResponseModel<LoginDto> resposta = new ResponseModel<LoginDto>();

            var usuarios = await _context.Usuarios.FirstOrDefaultAsync(usuarios => usuarios.Email == email);
            if (usuarios == null)
            {
                resposta.Mensagem = "Usuário não encontrado.";
                resposta.Status = false;
                return resposta;
            }

            if (!Verify(senha, usuarios.HashSenha))
            {
                resposta.Mensagem = "Senha incorreta.";
                resposta.Status = false;
                return resposta;
            }

            resposta.Dados = new LoginDto("guilherme nana", "guilherme nunu");
            resposta.Status = true;
            return resposta;
        }

        public async Task<ResponseModel<UsrUsuario>> Registro(string email, string senha, string nome)
        {
            ResponseModel<UsrUsuario> resposta = new ResponseModel<UsrUsuario>();

            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                resposta.Mensagem = "Preencha todos os campos!";
                resposta.Status = false;
                return resposta;

            }

            if (senha.Length < 6)
            {
                resposta.Mensagem = "A senha deve ter no mínimo 6 caracteres!";
                resposta.Status = false;
                return resposta;
            }


            var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarios => usuarios.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));

            if (usuario != null)
            {
                resposta.Mensagem = "Email já cadastrado!";
                resposta.Status = false;
                return resposta;
            }

            var hashSenha = HashPassword(senha);

            if (string.IsNullOrEmpty(hashSenha))
            {
                resposta.Mensagem = "Erro ao gerar hash da senha.";
                resposta.Status = false;
                return resposta;

            }

            UsrUsuario novoUsuario = new UsrUsuario
            {
                Nome = nome,
                Email = email,
                HashSenha = hashSenha
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            resposta.Dados = novoUsuario;
            resposta.Mensagem = "Usuário cadastrado com sucesso!";
            resposta.Status = true;
            return resposta;

        }


    }
}
