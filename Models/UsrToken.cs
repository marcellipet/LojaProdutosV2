using System.ComponentModel.DataAnnotations;

namespace LojaProdutosV2.Models
{
    public class UsrToken
    {
        [Required]
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
