using Microsoft.AspNetCore.Mvc;
using SaborCaseiro.Models;

[ApiController]
[Route("api/[controller]")]
public class PratosController : ControllerBase
{
    private readonly AppDbContext _context;

    public PratosController(AppDbContext context)
    {
        _context = context;
    }

    // [HttpGet]
    // public IActionResult Get()
    // {
    //     var pratos = _context.Pratos?.ToList();
    //     if (pratos == null) return NotFound();
    //     return Ok(pratos);
    // }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            if (_context.Pratos == null)
            {
                Console.WriteLine("Tabela 'Pratos' não foi inicializada no banco de dados.");
                return Problem("Tabela 'Pratos' não foi inicializada no banco de dados.");
            }

            var pratos = _context.Pratos.ToList();

            if (pratos == null || !pratos.Any())
            {
                Console.WriteLine("Nenhum prato encontrado.");
                return NotFound("Nenhum prato encontrado.");
            }

            Console.WriteLine($"Pratos retornados: {pratos.Count}");
            return Ok(pratos);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao obter pratos: {ex.Message}");
            return StatusCode(500, "Erro interno no servidor.");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var prato = _context.Pratos?.Find(id);
        if (prato == null) return NotFound();
        return Ok(prato);
    }

    [HttpPost]
    public IActionResult Create(Prato prato)
    {
        if (_context.Pratos == null) return Problem("Entity set 'AppDbContext.Pratos' is null.");
        _context.Pratos.Add(prato);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = prato.Id }, prato);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Prato prato)
    {
        var pratoExistente = _context.Pratos?.Find(id);
        if (pratoExistente == null) return NotFound();

        pratoExistente.Name = prato.Name;
        pratoExistente.Description = prato.Description;
        pratoExistente.Price = prato.Price;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (_context.Pratos == null) return Problem("Entity set 'AppDbContext.Pratos' is null.");
        var prato = _context.Pratos.Find(id);
        if (prato == null) return NotFound();

        _context.Pratos.Remove(prato);
        _context.SaveChanges();
        return NoContent();
    }
}
