using System;

namespace server_coworking.Models;

public class Espaco
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public int Capacidade { get; set; }
    public required string Localizacao { get; set; }
    public required ICollection<Reserva> Reservas { get; set; }
}


