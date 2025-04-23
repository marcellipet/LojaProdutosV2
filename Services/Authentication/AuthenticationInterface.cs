using LojaProdutos.Models;
using LojaProdutosV2.Dto;
using LojaProdutosV2.Models.RequestResponse;

namespace LojaProdutosV2.Services.Authentication
{
    public interface IAuthenticationInterface
    {
        Task<ResponseModel<LoginDto>> Logar(string email, string senha);
        Task<ResponseModel<UsrUsuario>> Registro(string email, string senha, string nome);
        Task<ResponseModel<RefreshTokenDto>> Token(string accessToken, string hash);

        //Task<ResponseModel<TokenResponse>> RefreshToken(string refreshToken, DateTime dateTime);

        Task<ResponseModel<TokenResponse>> AccesToken(string accessToken, string refreshToken);
        
    }

}
