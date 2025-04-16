
using System;
using LojaProdutos.Data;
using LojaProdutosV2.Services.Contato;
using LojaProdutosV2.Services.ContatoTipo;
using LojaProdutosV2.Services.Endereco;
using LojaProdutosV2.Services.Produto;
using LojaProdutosV2.Services.Usuario;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutosV2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
            builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();
            builder.Services.AddScoped<IContatoInterface, ContatoService>();
            builder.Services.AddScoped<IContatoTipoInterface, ContatoTipoService>();
            builder.Services.AddScoped<IEnderecoInterface, EnderecoService>();

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
