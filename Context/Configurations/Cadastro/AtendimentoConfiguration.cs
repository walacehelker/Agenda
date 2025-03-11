using Dados.Cadastro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.Configurations.Cadastro
{
    public class AtendimentoConfiguration : BaseConfiguration<Atendimento>
    {
        public override void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            base.Configure(builder);

            const string tabela = "atendimentos";

            builder.ToTable(tabela);
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
              .HasMaxLength(50)
              .HasColumnName("id")
              .IsRequired();

            builder.Property(e => e.Descricao)
              .HasColumnName("descricao")
              .HasMaxLength(400)
              .IsRequired();

            builder.Property(e => e.DataAtendimento)
              .HasColumnName("data_atendimento")
              .HasColumnType("datetime2")
              .IsRequired();

            builder.Property(e => e.PessoaId)
              .HasColumnName("id_pessoa")
              .HasMaxLength(50)
              .IsRequired();

            builder.Property(e => e.TipoAtendimentoId)
              .HasColumnName("id_tipo_atendimento")
              .HasMaxLength(50)
              .IsRequired();

            builder
              .HasOne(e => e.TipoAtendimento)
              .WithMany(u => u.AtendimentoList)
              .HasForeignKey(e => e.TipoAtendimentoId)
              .OnDelete(DeleteBehavior.Cascade)
              .IsRequired();

            builder
              .HasOne(e => e.Pessoa)
              .WithMany(u => u.AtendimentoList)
              .HasForeignKey(e => e.PessoaId)
              .OnDelete(DeleteBehavior.Cascade)
              .IsRequired();
        }
    }
}
