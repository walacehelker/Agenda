using Dados.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.Configurations.Cadastro
{
    public class UsuarioLoginConfiguration : BaseConfiguration<UsuarioLogin>
    {
        public override void Configure(EntityTypeBuilder<UsuarioLogin> builder)
        {
            base.Configure(builder);

            const string tabela = "usuario_login";

            builder.ToTable(tabela);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
              .HasColumnName("id")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(e => e.Usuario)
              .HasColumnName("usuario")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(e => e.Email)
              .HasColumnName("email")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(e => e.Senha)
              .HasColumnName("senha")
              .HasMaxLength(100)
              .IsRequired();

            builder
              .HasOne(e => e.Pessoa)
              .WithOne(u => u.UsuarioLogin)
              .HasForeignKey<UsuarioLogin>(e => e.PessoaId)
              .OnDelete(DeleteBehavior.Cascade)
              .IsRequired();
        }
    }
}
