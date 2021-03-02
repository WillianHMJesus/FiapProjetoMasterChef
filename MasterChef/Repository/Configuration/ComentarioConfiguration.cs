using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentario");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Texto).HasMaxLength(200).IsRequired();
            builder.Property<int>("ReceitaForeignKey");

            builder.HasOne(x => x.Receita).WithMany(x => x.Comentarios).HasForeignKey("ReceitaForeignKey");
        }
    }
}
