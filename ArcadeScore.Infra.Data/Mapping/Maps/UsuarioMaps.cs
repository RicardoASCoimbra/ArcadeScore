using ArcadeScore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArcadeScore.Infra.Data.Mapping.Maps
{
    public class UsuarioMaps : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("Usuario");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Sobrenome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Escolaridade).IsRequired();
            builder.Property(x => x.Excluido).HasDefaultValue(false);


            builder.HasKey(x => x.Id);
        }
    }
}
