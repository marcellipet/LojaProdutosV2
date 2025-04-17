using LojaProdutos.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LojaProdutosV2.Dto
{
    public class EnderecoAtualizarDto
    {
        public long Id { get; protected set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public char Estado { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string Bairro { get; set; }

        //// nao sei se fiz certo 
        //[ForeignKey("UsrUsuarioRefId")]
        //[Required]
        //public UsrUsuario IdUsuario { get; set; }
    }
}
