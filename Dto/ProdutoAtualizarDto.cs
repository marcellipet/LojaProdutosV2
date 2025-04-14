using System.ComponentModel.DataAnnotations;

namespace LojaProdutosV2.Dto
{
    public class ProdutoAtualizarDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public string Foto { get; set; } = string.Empty;
    }
}
