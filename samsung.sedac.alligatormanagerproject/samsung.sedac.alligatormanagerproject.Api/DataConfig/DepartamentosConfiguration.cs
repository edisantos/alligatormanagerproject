using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using samsung.sedac.alligatormanagerproject.Api.Entities;

namespace samsung.sedac.alligatormanagerproject.Api.DataConfig
{
    public class DepartamentosConfiguration : IEntityTypeConfiguration<Departamentos>
    {
        public void Configure(EntityTypeBuilder<Departamentos> builder)
        {
            builder.ToTable("Departamentos");

            builder.HasKey(dep => dep.Id);
            builder.Property(dep => dep.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany<Users>()
                .WithOne()
                .HasForeignKey(dep => dep.DepartamentoId)
                .IsRequired();
        }
    }
}
