
using System;
using LojaProdutos.Data;
using LojaProdutosV2.Extensions;
using LojaProdutosV2.Services.Contato;
using LojaProdutosV2.Services.ContatoTipo;
using LojaProdutosV2.Services.Endereco;
using LojaProdutosV2.Services.Produto;
using LojaProdutosV2.Services.Usuario;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LojaProdutos.CrossCutting.IoC;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace LojaProdutosV2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

                //builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
                //{
                //    options.Password.RequireDigit = true;
                //    options.Password.RequireUppercase = true;
                //    options.Password.RequireLowercase = true;
                //    options.Password.RequiredLength = 8;
                //    options.SignIn.RequireConfirmedEmail = true;
                //}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Dendency Injection

            builder.Services.AddDependencyInjection();

            #endregion

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
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
