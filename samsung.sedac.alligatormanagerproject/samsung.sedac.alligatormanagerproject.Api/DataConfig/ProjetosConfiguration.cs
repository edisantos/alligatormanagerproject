using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using samsung.sedac.alligatormanagerproject.Api.Entities;

namespace samsung.sedac.alligatormanagerproject.Api.DataConfig
{
    public class ProjetosConfiguration : IEntityTypeConfiguration<Projetos>
    {
        public void Configure(EntityTypeBuilder<Projetos> builder)
        {
            builder.ToTable("Projetos");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Data)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.Solicitante)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(p => p.DepartamentoId)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(p => p.Titulo)
               .HasColumnType("varchar")
               .HasMaxLength(50)
               .IsRequired();

            builder.Property(p => p.Descricao)
               .HasColumnType("varchar")
               .HasMaxLength(300)
               .IsRequired();

            builder.Property(p => p.UrlFluxograma)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(p => p.IsApproved)
               .HasColumnType("int")
              .IsRequired();
        }
    }
}
