using System.ComponentModel.DataAnnotations;

namespace LojaProdutosV2.Models
{
    public class UsrUsuarioRegistro
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        
        public string Senha { get; set; }
    }
}
