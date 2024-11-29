using System;

namespace server_coworking.Models;

public class Reserva
{
    public int Id { get; set; }
    public int EspacoId { get; set; }
    public required Espaco Espaco { get; set; }
    public required string Usuario { get; set; }
    public DateTime Data { get; set; }
    public TimeSpan Horario { get; set; }
}

