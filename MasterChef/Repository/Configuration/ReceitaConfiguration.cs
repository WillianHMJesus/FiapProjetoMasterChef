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
            builder.Property(x => x.Cobertura).HasMaxLength(1000).IsUnicode();
            builder.Property(x => x.InformacaoAdicional).HasMaxLength(200).IsUnicode();
            builder.Property(x => x.DiretorioImagem).HasMaxLength(200).IsUnicode();

            builder.HasMany(x => x.Comentarios).WithOne(x => x.Receita).OnDelete(DeleteBehavior.Cascade).IsRequired();
        }
    }
}
