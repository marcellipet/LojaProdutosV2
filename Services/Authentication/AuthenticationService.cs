using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LojaProdutos.Data;
using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models;
using LojaProdutosV2.Models.RequestResponse;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

            //public async Task<ResponseModel<TokenResponse>> AccesToken(string accessToken, string refreshToken)
            //{
            //    ResponseModel<TokenResponse> resposta = new ResponseModel<TokenResponse>();

            //    if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
            //    {
            //        resposta.Mensagem = "Preencha todos os campos!";
            //        resposta.Status = false;
            //        return resposta;
            //    }
            //    var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarios => usuarios.Equals(refreshToken));

            //    if (usuario == null)
            //    {
            //        resposta.Mensagem = "Refresh token inválido.";
            //        resposta.Status = false;
            //        return resposta;
            //    }

            //    resposta.Dados = new TokenResponse(accessToken, refreshToken, DateTime.UtcNow.AddHours(1));
            //    resposta.Status = true;
            //    return resposta;


            //}

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

                resposta.Dados = new LoginDto(email, senha);
                resposta.Status = true;
                return resposta;
            }

            public async Task<ResponseModel<UsrToken>> RefreshToken(string refreshToken, DateTime dateTime)
            {
                ResponseModel<UsrToken> resposta = new ResponseModel<UsrToken>();

                if (string.IsNullOrEmpty(refreshToken))
                {
                    resposta.Mensagem = "Refresh token inválido.";
                    resposta.Status = false;
                    return resposta;
                }
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(usuarios => usuarios.Equals(refreshToken));
                if (usuario == null)
                {
                    resposta.Mensagem = "Refresh token inválido.";
                    resposta.Status = false;
                    return resposta;
                }

                var accessToken = Guid.NewGuid().ToString();
                var newRefreshToken = Guid.NewGuid().ToString();
                var expiration = DateTime.UtcNow.AddHours(1);

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

            //public async Task<ResponseModel<RefreshTokenDto>> ValidateAndGenerateToken(string accessToken, string hash)
            //{
            //    ResponseModel<RefreshTokenDto> resposta = new ResponseModel<RefreshTokenDto>();

            //    if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(hash))
            //    {
            //        resposta.Mensagem = "Preencha todos os campos!";
            //        resposta.Status = false;
            //        return resposta;
            //    }

            //    var refresh = await _context.RefreshTokens.FirstOrDefaultAsync(refresh => refresh.Token.Equals(hash));

            //    if (refresh == null)
            //    {
            //        resposta.Mensagem = "Esse Token é inválido";
            //        resposta.Status = false;
            //        return resposta;
            //    }

            //    accessToken = Guid.NewGuid().ToString();
            //    hash = Guid.NewGuid().ToString();

            //    var usuario = _context.Usuarios.FirstOrDefault(x => x.Id == 2);

            //    if (usuario == null)
            //    {
            //        resposta.Mensagem = "Usuário não encontrado.";
            //        resposta.Status = false;
            //        return resposta;
            //    }

            //    _context.Add(new RefreshToken
            //    {
            //        Token = hash,
            //        IdUsuario = 2
            //    });

            //    _context.SaveChanges();

            //    resposta.Dados = new RefreshTokenDto
            //    {
            //        Token = accessToken,
            //        HashRefresh = hash
            //    };
            //    resposta.Status = true;
            //    return resposta;
            //}
        

        public string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key89uu98y98y98erwefsfcvcdwerergg3g34"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
