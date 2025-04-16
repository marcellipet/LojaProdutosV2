using System.ComponentModel.DataAnnotations;

namespace LojaProdutosV2.Dto
{
    public class ContatoTipoAtualizarDto
    {
        public long Id { get; protected set; }
        public string Nome { get; set; }
        public string Descricao { get; set; } = string.Empty;

    }
}
