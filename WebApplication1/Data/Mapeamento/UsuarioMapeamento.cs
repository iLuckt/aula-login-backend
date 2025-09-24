using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Email).HasColumnType("varchar(50)");
        builder.Property(t => t.Senha).HasColumnType("varchar(50)");

    }
}