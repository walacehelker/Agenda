using Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Context.Configurations
{
    public abstract class BaseConfiguration<TBaseDbEntity> : IEntityTypeConfiguration<TBaseDbEntity> where TBaseDbEntity : Base
    {
        public virtual void Configure(EntityTypeBuilder<TBaseDbEntity> builder)
        {
            ConfigureEntityInternal(builder);
        }

        private void ConfigureEntityInternal(EntityTypeBuilder<TBaseDbEntity> builder)
        {
            builder.Property(c => c.DataCadastro)
              .HasColumnName("data_cadastro")
              .IsRequired();

            builder.Property(c => c.Excluido)
              .HasColumnName("excluido")
              .IsRequired();

            builder.Property(c => c.DataExclusao)
              .HasColumnName("data_exclusao")
              .IsRequired(false);
        }
    }
}
