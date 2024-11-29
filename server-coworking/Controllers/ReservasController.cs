using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_coworking.Models;
using server_coworking.Data;
using Reserva = server_coworking.Data.Reserva;

namespace server_coworking.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservasController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReservasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reserva>>> ListarReservas()
    {
        return await _context.Reservas.Include(r => r.Espaco).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Reserva>> CriarReserva(Reserva reserva)
    {
        _context.Reservas.Add(reserva);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(ListarReservas), new { id = reserva.Id }, reserva);
    }
}
