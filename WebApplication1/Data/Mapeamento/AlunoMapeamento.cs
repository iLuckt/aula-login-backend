using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class AlunoMapeamento : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name).HasColumnType("varchar(50)");
        builder.Property(t => t.Matricula).HasColumnType("int");
        builder.Property(t => t.DataNascimento).HasColumnType("Date");
        builder.Property(t => t.Cpf).HasColumnType("varchar(20)");
        builder.Property(t => t.Cep).HasColumnType("varchar(15)");
        builder.Property(t => t.Endereco).HasColumnType("varchar(50)");
        builder.Property(t => t.Bairro).HasColumnType("varchar(50)");
        builder.Property(t => t.Cidade).HasColumnType("varchar(50)");
        builder.Property(t => t.Numero).HasColumnType("varchar(20)");

    }
}