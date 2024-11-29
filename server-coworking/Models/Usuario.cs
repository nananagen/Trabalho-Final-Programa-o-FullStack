using System;

namespace server_coworking.Models;

public class Usuario
{
    public long Id { get ; set; }
    public string Nome { get ; set; } = string.Empty;
    public string Email { get ; set; } = string.Empty;

    public string HashSenha { get ; set; } = string.Empty;
    public string Role { get ; set; } = string.Empty;

}
