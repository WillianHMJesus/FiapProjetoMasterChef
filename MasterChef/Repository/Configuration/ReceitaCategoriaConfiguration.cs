using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ReceitaCategoriaConfiguration : IEntityTypeConfiguration<ReceitaCategoria>
    {
        public void Configure(EntityTypeBuilder<ReceitaCategoria> builder)
        {
            builder.ToTable("ReceitaCategoria");
            builder.HasKey(x => x.Id);

            builder.HasOne(bc => bc.Receita)
                .WithMany(b => b.ReceitasCategorias)
                .HasForeignKey(bc => bc.ReceitaId);

            builder.HasOne(bc => bc.Categoria)
                .WithMany(c => c.ReceitasCategorias)
                .HasForeignKey(bc => bc.CategoriaId);
        }
    }
}
