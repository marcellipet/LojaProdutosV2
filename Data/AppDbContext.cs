using LojaProdutos.Models;
using LojaProdutosV2.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaProdutos.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<PrdProduto> Produtos { get; set; }
        public DbSet<UsrUsuario> Usuarios { get; set; }
        public DbSet<CntContato> Contatos { get; set; }
        public DbSet<CntContatoTipo> ContatoTipos { get; set; }
        public DbSet<EndEndereco> Enderecos { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}
