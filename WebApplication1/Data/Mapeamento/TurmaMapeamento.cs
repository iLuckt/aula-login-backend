using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class TurmaMapeamento : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable("Turma");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).ValueGeneratedOnAdd();

        builder.Property(t => t.Nome).HasColumnType("varchar(20)");
        builder.Property(t => t.DataInicio).HasColumnType("Date");
        builder.Property(t => t.DataFim).HasColumnType("Date");

    }
}