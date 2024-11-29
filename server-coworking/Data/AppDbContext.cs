using Microsoft.EntityFrameworkCore;

namespace server_coworking.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Espaco> Espacos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }

    // Models
    public class Espaco
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public string Localizacao { get; set; }
    }

    public class Reserva
    {
        public int Id { get; set; }
        public int EspacoId { get; set; }
        public DateTime DataHora { get; set; }
        public string Usuario { get; set; }

        public Espaco Espaco { get; set; } 
    }
}
