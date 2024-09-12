namespace EvoSystems.WebAPI.Treinamento1.Models;

public class HeroiBatalha
{
    
    // ManyToMany
    public int HeroId { get; set; }
    public Heroi Heroi { get; set; }
    
    public int BatalhaId { get; set; }
    public Batalha Batalha { get; set; }
}