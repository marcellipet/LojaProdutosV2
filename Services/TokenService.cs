//using System.IdentityModel.Tokens.Jwt;
//using System.Text;
//using LojaProdutos.Models;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;

//namespace LojaProdutosV2.Services
//{
//    public class TokenService
//    {
//        public string Generate(UsrUsuario usrUsuario)
//        {
//            var handler = new JwtSecurityTokenHandler();
//            var key = Encoding.UTF8.GetBytes(Configuration.Private);

//            var credentials = new SigningCredentials
//                (new SymmetricSecurityKey(key),
//                algorithm: SecurityAlgorithms.HmacSha256Signature);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                SigningCredentials = credentials,
//                Expires = DateTime.UtcNow.AddHours(2)
//            };

//            var token = handler.CreateToken(tokenDescriptor);

//            return handler.WriteToken(token);
//        }
//    }
//}
