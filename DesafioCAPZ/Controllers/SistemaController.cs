using DesafioCAPZ.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesafioCAPZ.Controllers;

[ApiController]
[Route("[controller]")]
public class SistemaController : ControllerBase
{

    private static List<Dado> dados = new List<Dado>();
    private static int id = 0;

    [HttpPost]
    public IActionResult AdicionaDado([FromBody] Dado dado)
    {
        dado.Id = id++;
        dados.Add(dado);
        return CreatedAtAction(nameof(RecuperaDadoPorID), 
            new {id = dado.Id}, dado);
    } 

    [HttpGet]
    public IEnumerable<Dado> RecuperaDados([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return dados.Skip(skip).Take(take);
    }

    //[HttpGet("{id}")]
    //public Dado? RecuperaDadoPorID(string id) 
    //{
    //    return dados.FirstOrDefault(dado => dado.MaterialID == id);
    //}

    [HttpGet("{id}")]
    public IActionResult RecuperaDadoPorID(int id)
    {
        var dado = dados.FirstOrDefault(dado => dado.Id == id);
        if (dado == null) return NotFound();
        return Ok(dado);
    }
}