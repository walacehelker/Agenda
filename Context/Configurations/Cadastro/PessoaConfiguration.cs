using Dados.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.Configurations.Cadastro
{
    public class PessoaConfiguration : BaseConfiguration<Pessoa>
    {
        public override void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            base.Configure(builder); // Chama o método base para configurar propriedades comuns

            const string tabela = "cad_pessoas";

            builder.ToTable(tabela);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
              .HasColumnName("id")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(e => e.Nome)
              .HasColumnName("nome_completo")
              .HasMaxLength(200)
              .IsRequired();

            builder.Property(e => e.DataNascimento)
              .HasColumnName("data_nascimento")
              .HasColumnType("datetime2")
              .IsRequired();

            builder.Property(e => e.Cpf)
              .HasColumnName("cpf")
              .HasMaxLength(50)
              .IsRequired(false);

            builder.Property(e => e.Rg)
              .HasColumnName("rg")
              .HasMaxLength(50)
              .IsRequired(false);

            builder.Property(e => e.Cnpj)
              .HasColumnName("cnpj")
              .HasMaxLength(50)
              .IsRequired(false);

            builder.Property(e => e.Crm)
              .HasColumnName("crm")
              .HasMaxLength(50)
              .IsRequired(false);

            builder.Property(e => e.TipoUsuario)
              .HasColumnName("tipo_usuario")
              .HasColumnType("int")
              .IsRequired();
        }
    }
}
