using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
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
    }
}
