using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LojaProdutos.Models;

namespace LojaProdutosV2.Models
{
    [Table("RefreshToken")]
    public class RefreshToken
    {
        [Key]
        public long Id { get; protected set; }
        public string Token { get;  set; }

        [ForeignKey(nameof(UsrUsuario))]
        public long IdUsuario { get; set; }

        public UsrUsuario UsrUsuario { get; init; }

    }

}
