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
            builder.HasKey(x => new { x.ReceitaId, x.CategoriaId });
            builder.HasOne(x => x.Receita).WithMany(x => x.ReceitasCategorias).HasForeignKey(x => x.ReceitaId);
            builder.HasOne(x => x.Categoria).WithMany(x => x.ReceitasCategoria).HasForeignKey(x => x.CategoriaId);
        }
    }
}
