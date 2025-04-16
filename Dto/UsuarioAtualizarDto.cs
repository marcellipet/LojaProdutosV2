namespace LojaProdutosV2.Dto
{
    public class UsuarioAtualizarDto
    {
        public long Id { get; protected set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; }
    }
}
