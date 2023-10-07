namespace EPIlist.Models;
public class Equipe
{
    public int EquipeID { get; set; }
    public string NomeEquipe { get; set; }
    public Unidade? Unidade { get; set; }
    public int UnidadeID {get; set; }
    public List<Usuario>? Integrantes { get; set; }
    public Usuario? Lider { get; set; }
}
