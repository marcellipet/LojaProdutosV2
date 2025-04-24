using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LojaProdutosV2.Models;
using Microsoft.AspNetCore.Identity;

namespace LojaProdutos.Models
{
    [Table("Usr_Usuario")]
    public class UsrUsuario 
    {
        [Key]
        public long Id { get; protected set; }


        [Required]
        [StringLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres!")]
        public string Nome { get; set; } = string.Empty;


        [Required(ErrorMessage ="Esse campo não pode ser vazio!")]
        [DataType(DataType.EmailAddress, ErrorMessage ="E-mail inválido!")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Esse campo não pode ser vazio!")]
        //[DataType(DataType.Password, ErrorMessage = "Senha inválida!")]
        //[StringLength(20, ErrorMessage = "A senha deve ter no máximo 20 caracteres!")]
        //[MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres!")]
        //public string Senha { get; set; }
        

        public string? HashSenha { get; set; }

    }
}
