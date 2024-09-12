namespace EvoSystems.WebAPI.Treinamento1.Models;

public class Arma
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    // One(heroi)ToMany
    public Heroi Heroi { get; set; }
    public int HeroiId { get; set; }
}