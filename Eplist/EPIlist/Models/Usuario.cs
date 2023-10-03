namespace EPIlist.Models;
public class Usuario
{   
    
    public int UsuarioID { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public string Senha { get; set; }
    public string CPF { get; set; }
    public string Cargo { get; set; }
    //list epi
    //public List<Epi> Epis { get; set; }
}