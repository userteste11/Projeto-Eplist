namespace EPIlist.Models;
public class Unidade
{
    public int UnidadeID { get; set; }
    public string? Nome { get; set; }
    public Usuario? Tecnico { get; set; }
    public int TecnicoID { get; set; }
    public Usuario? Gestor { get; set; }
    public int GestorID { get; set; }
}
