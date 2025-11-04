using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class BancoContexto : DbContext
{
    public BancoContexto(DbContextOptions<BancoContexto> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
        modelBuilder.ApplyConfiguration(new AlunoMapeamento());
        modelBuilder.ApplyConfiguration(new ProfessorMapeamento());
        modelBuilder.ApplyConfiguration(new TurmaMapeamento());
    }

    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Aluno> Aluno { get; set; }
    public DbSet<Professores> Professores { get; set; }
    public DbSet<Turma> Turma { get; set; }
}