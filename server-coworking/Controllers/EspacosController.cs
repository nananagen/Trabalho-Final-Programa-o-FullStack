using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server_coworking.Models;
using server_coworking.Data;
using Espaco = server_coworking.Data.Espaco;

namespace server_coworking.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EspacosController : ControllerBase
{
    private readonly AppDbContext _context;

    public EspacosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Espaco>>> ListarEspacos()
    {
        return await _context.Espacos.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Espaco>> CriarEspaco(Espaco espaco)
    {
        _context.Espacos.Add(espaco);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(ListarEspacos), new { id = espaco.Id }, espaco);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarEspaco(int id, Espaco espaco)
    {
        if (id != espaco.Id)
        {
            return BadRequest();
        }

        _context.Entry(espaco).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EspacoExiste(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletarEspaco(int id)
    {
        var espaco = await _context.Espacos.FindAsync(id);
        if (espaco == null)
        {
            return NotFound();
        }

        _context.Espacos.Remove(espaco);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool EspacoExiste(int id) => _context.Espacos.Any(e => e.Id == id);
}
