namespace LojaProdutosV2.Dto
{
    public class LoginDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public LoginDto(string accessToken, string refreshToken)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }

    public class RefreshTokenDto
    {
        public string RefreshToken { get; set; }
    }
}