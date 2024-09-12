namespace EvoSystems.WebAPI.Treinamento1.Models;

public class IdentidadeSecreta
{
    public int Id { get; set; }
    public string NomeReal { get; set; }
    
    // OneToOne
    public int HeroiId { get; set; }
    public Heroi Heroi { get; set; }
}