using LojaProdutos.Models;

namespace LojaProdutosV2.Dto
{
    public class ContatoAtualizarDto
    {
        public long Id { get; protected set; }
        public string NumeroTelefone { get; set; }
    }
}
