namespace LojaProdutosV2.Dto
{
    public class RefreshTokenDto
    {
        public long Id { get; protected set; }
        public string Token { get; set; } = string.Empty;
    }
}
