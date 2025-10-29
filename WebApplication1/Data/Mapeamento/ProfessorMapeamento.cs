using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class ProfessorMapeamento : IEntityTypeConfiguration<Professores>
{
    public void Configure(EntityTypeBuilder<Professores> builder)
    {
        builder.ToTable("Professor");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();

        builder.Property(t => t.Nome).HasColumnType("varchar(50)");
        builder.Property(t => t.Email).HasColumnType("varchar(50)");
        builder.Property(t => t.Disciplina).HasColumnType("varchar(20)");

    }
}