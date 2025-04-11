using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaProdutos.Models
{
    [Table("Cnt_Contato")]
    public class CntContato
    {
        [Key]
        public long Id { get; protected set; }

        [Required]
        [StringLength(14, ErrorMessage = "O número deve ter no máximo 14 caracteres!")]
        [Display(Name = "Número de telefone")]
        [DataType(DataType.PhoneNumber)]
        public string NumeroTelefone { get; set; }

        // nao sei se fiz certo 
        [ForeignKey("UsrUsuarioRefId")]
        public UsrUsuario IdUsuario { get; set; }

        public CntContatoTipo ContatoTipo { get; set; }
    }
}
