using System.ComponentModel.DataAnnotations;

namespace LojaProdutosV2.Dto
{
    public class ProdutoAtualizarDto
    {
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        [Required]
        public string Foto { get; set; } = string.Empty;
    }
}
