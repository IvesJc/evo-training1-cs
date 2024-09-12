using System.Data;

namespace EvoSystems.WebAPI.Treinamento1.Models;

public class Batalha
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DtInicio { get; set; }
    public DateTime DtFim { get; set; }
    
    // ManyToMany
    public List<HeroiBatalha> HeroisBatalhas { get; set; }
    
}