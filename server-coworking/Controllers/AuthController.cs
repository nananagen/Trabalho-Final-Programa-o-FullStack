using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using server_coworking.Models;

namespace server_coworking.Controllers
{
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] Usuario usuario)
    {
        // Ajustar
        if (usuario.Email == "admin@coworking.com" && usuario.HashSenha == "123456")
        {
            var token = GerarToken(usuario);
            return Ok(new { token });
        }

        return Unauthorized();
    }

    private string GerarToken(Usuario usuario)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuario.Email),
            new Claim(ClaimTypes.Role, "Admin") // Ajustar
        };

        var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sua-chave-secreta"));
        var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);
        // Ajustar
        var token = new JwtSecurityToken(
            issuer: "server-coworking",
            audience: "server-coworking",
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credenciais
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

}
