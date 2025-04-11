using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace LojaProdutos.Models
{
    [Table("Usr_Usuarios")]
    public class UsrUsuario : IdentityUser
    {
        [Key]
        public long Id { get; protected set; }


        [Required]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres!")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage ="Esse campo não pode ser vazio!")]
        [DataType(DataType.EmailAddress, ErrorMessage ="E-mail inválido!")]
        public string Email { get; set; }
    }
}
