namespace EvoSystems.WebAPI.Treinamento1.Models;

public class Heroi
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    // OneToOne
    public IdentidadeSecreta IdentidadeSecreta { get; set; }
    
    // OneToMany
    public List<Arma> Armas { get; set; }
    
    // ManyToMany
    public List<HeroiBatalha> HeroisBatalhas { get; set; }
}