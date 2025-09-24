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
    }

    public DbSet<Usuario> Usuario { get; set; }
}