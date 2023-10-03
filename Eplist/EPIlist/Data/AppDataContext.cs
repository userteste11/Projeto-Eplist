
using EPIlist.Models;
using Microsoft.EntityFrameworkCore;

namespace Namespace.Data;
public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {

    }

    //Classes que vão se tornar tabelas no banco de dados
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Epi> Epis { get; set; }
    public DbSet<Unidade> Unidades { get; set; }
    public DbSet<Equipe> Equipes { get; set; }
    
}