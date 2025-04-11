using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LojaProdutos.Models
{
    [Table("Cnt_ContatoTipo")]
    public class CntContatoTipo
    {
        [Key]
        public long Id { get; protected set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tipo de contato")]
        public string Nome { get; protected set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<CntContato> Contatos { get; set; } = new List<CntContato>();
    }
}
