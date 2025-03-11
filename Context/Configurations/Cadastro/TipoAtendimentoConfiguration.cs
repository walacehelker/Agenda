using Dados.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.Configurations.Cadastro
{
    public class TipoAtendimentoConfiguration : BaseConfiguration<TipoAtendimento>
    {
        public override void Configure(EntityTypeBuilder<TipoAtendimento> builder)
        {
            base.Configure(builder);

            const string tabela = "tipos_atendimentos";

            builder.ToTable(tabela);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
              .HasColumnName("id")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(e => e.Nome)
              .HasColumnName("nome")
              .HasMaxLength(75)
              .IsRequired();

            builder.Property(e => e.Descricao)
              .HasColumnName("descricao")
              .HasMaxLength(400)
              .IsRequired();
        }
    }
}
