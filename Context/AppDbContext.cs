using Context.Configurations.Cadastro;
using Dados.Cadastro;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {          
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<UsuarioLogin> UsuariosLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioLoginConfiguration());
            modelBuilder.ApplyConfiguration(new TipoAtendimentoConfiguration());
            modelBuilder.ApplyConfiguration(new AtendimentoConfiguration());
        }

    }
}
