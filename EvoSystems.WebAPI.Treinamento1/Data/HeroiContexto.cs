using EvoSystems.WebAPI.Treinamento1.Models;
using Microsoft.EntityFrameworkCore;

namespace EvoSystems.WebAPI.Treinamento1.Data;

public class HeroiContexto : DbContext
{
    public DbSet<Heroi> Herois { get; set; }
    public DbSet<Batalha> Batalhas { get; set; }
    public DbSet<Arma> Armas { get; set; }
    public DbSet<HeroiBatalha> HeroiBatalhas { get; set; }
    public DbSet<IdentidadeSecreta> IdentidadeSecretas { get; set; }

    public HeroiContexto(DbContextOptions<HeroiContexto> options) : base(options)
    {
    }

    // ManyToMany 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HeroiBatalha>(entity =>
        {
            entity.HasKey(
                e => new { e.BatalhaId, e.HeroId});
        });
    }
}