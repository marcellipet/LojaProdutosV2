using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaProdutos.Models
{
    [Table("Prd_Produtos")]
    public class PrdProduto
    {
        [Key]
        public long Id { get; protected set; }

        [Required]
        public string Nome { get; set; }

        [Display(Name= "Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required]
        public string Foto { get; set; }
    }
}
