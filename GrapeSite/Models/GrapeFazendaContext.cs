using System.Data.Entity;
using GrapeSite.Models;

namespace GrapeSite.Models
{
    public class GrapeFazendaContext : DbContext
    {
        static GrapeFazendaContext()
        {
            
            Database.SetInitializer<GrapeFazendaContext>(null);
        }

        public GrapeFazendaContext() : base("name=GrapeFazendaContext") { }

        // Tabelas do banco de dados
        public DbSet<Promocao> Promocoes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }  
    }
}
