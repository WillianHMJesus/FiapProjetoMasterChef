using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ReceitaConfiguration : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.ToTable("Receita");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.RendimentoPorcoes).IsRequired();
            builder.Property(x => x.TempoPreparo).HasMaxLength(1000).IsRequired().IsUnicode();
            builder.Property(x => x.Ingredientes).HasMaxLength(1000).IsRequired().IsUnicode();
            builder.Property(x => x.ModoPreparo).HasMaxLength(1000).IsRequired().IsUnicode();
            builder.Property(x => x.Cobertura).HasMaxLength(1000).IsRequired().IsUnicode();
            builder.Property(x => x.InfoAdicional).HasMaxLength(200).IsRequired().IsUnicode();
            builder.Property(x => x.CaminhoImagem).HasMaxLength(200).IsRequired().IsUnicode();
            builder.HasMany(c => c.Comentarios).WithOne(e => e.Receita).OnDelete(DeleteBehavior.Cascade).IsRequired();
        }
    }
}
