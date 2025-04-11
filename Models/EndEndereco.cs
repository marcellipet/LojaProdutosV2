using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaProdutos.Models
{
    [Table("End_Endereco")]
    public class EndEndereco
    {
        [Key]
        public long Id { get; protected set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public char Estado { get; set; }

        [Required]
        [Display(Name ="Número")]
        public int Numero { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string Bairro { get; set; }

        // nao sei se fiz certo 
        [ForeignKey("UsrUsuarioRefId")]
        public UsrUsuario IdUsuario { get; set; }
    }
}
