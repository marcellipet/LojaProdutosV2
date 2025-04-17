using LojaProdutosV2.Services.Authentication;
using LojaProdutosV2.Services.Contato;
using LojaProdutosV2.Services.ContatoTipo;
using LojaProdutosV2.Services.Endereco;
using LojaProdutosV2.Services.Produto;
using LojaProdutosV2.Services.Usuario;

namespace LojaProdutosV2.Extensions
{
    public static class ServiceExtension
    {
        public static void AddDependencyInjection(this IServiceCollection services) {
            services.AddScoped<IProdutoInterface, ProdutoService>();
            services.AddScoped<IUsuarioInterface, UsuarioService>();
            services.AddScoped<IContatoInterface, ContatoService>();
            services.AddScoped<IContatoTipoInterface, ContatoTipoService>();
            services.AddScoped<IEnderecoInterface, EnderecoService>();
            services.AddScoped<IAuthenticationInterface, AuthenticationService>();
        }
    }
}
