using LojaProdutosV2.Services.Authentication;
using LojaProdutosV2.Services.Contato;
using LojaProdutosV2.Services.ContatoTipo;
using LojaProdutosV2.Services.Endereco;
using LojaProdutosV2.Services.Jwt;
using LojaProdutosV2.Services.Produto;
using LojaProdutosV2.Services.Usuario;

namespace LojaProdutosV2.Extensions
{
    public static class ServiceExtension
    {
        public static object JwtBearerDefaults { get; private set; }

        public static void AddDependencyInjection(this IServiceCollection services) 
        {
            services.AddScoped<IProdutoInterface, ProdutoService>();
            services.AddScoped<IUsuarioInterface, UsuarioService>();
            services.AddScoped<IContatoInterface, ContatoService>();
            services.AddScoped<IContatoTipoInterface, ContatoTipoService>();
            services.AddScoped<IEnderecoInterface, EnderecoService>();
            services.AddScoped<IAuthenticationInterface, AuthenticationService>();
            services.AddScoped<IJwtManagerInterface, JwtManagerService>();
        }

        public static void ConfigureJwt(this IServiceCollection services)
        {

            //var jwtConfiguration = services.BuildServiceProvider().GetRequiredService<IJwtConfiguration>();

            //services.AddAuthentication(options =>
            //{
            //    //options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(options =>
            //    {
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidateLifetime = true,
            //            ValidateIssuerSigningKey = true,
            //            ValidIssuer = jwtConfiguration.Issuer,
            //            ValidAudience = jwtConfiguration.Audience,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.SecretKey)),
            //            ClockSkew = TimeSpan.Zero
            //        };
            //    }
        }
    }
}
