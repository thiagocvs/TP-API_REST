using Microsoft.AspNetCore.Mvc;

namespace TP_API_REST.Controllers;

[ApiController]
[Route("[controller]")]
public class MascotaController : ControllerBase
{
    private static readonly List<Mascota> Mascotas =
    [
        new Perro { Id = 1, Nombre = "Firulais", Edad = 5, Raza = "Labrador" },
        new Gato  { Id = 2, Nombre = "Luna",     Edad = 3, Color = "Blanco" },
        new Perro { Id = 3, Nombre = "Rocky",    Edad = 8, Raza = "Bulldog" },
        new Gato  { Id = 4, Nombre = "Michi",    Edad = 10, Color = "Naranja" }
    ];

    //estaba probando algo y funciono, asi q no lo toque.
    private static int ultimoId = 4;

    // GET /Mascota obtener todas las mascotas
    [HttpGet]
    public ActionResult<IEnumerable<Mascota>> GetTodas()
    {
        return Ok(Mascotas);
    }

    // GET /Mascota/{id} obtener una mascota por su Id
    [HttpGet("{id:int}")]
    public ActionResult<Mascota> GetById(int id)
    {
        Mascota? mascota = BuscarPorId(id);

        if (mascota == null)
        {
            return NotFound($"No existe una mascota con el Id {id}.");
        }

        return Ok(mascota);
    }

    // POST /Mascota/perro registrar un nuevo perro
    [HttpPost("perro")]
    public ActionResult<Perro> PostPerro(Perro perro)
    {
        ultimoId = ultimoId + 1;
        perro.Id = ultimoId;
        Mascotas.Add(perro);

        return CreatedAtAction(nameof(GetById), new { id = perro.Id }, perro);
    }

    // POST /Mascota/gato registrar un nuevo gato
    [HttpPost("gato")]
    public ActionResult<Gato> PostGato(Gato gato)
    {
        ultimoId = ultimoId + 1;
        gato.Id = ultimoId;
        Mascotas.Add(gato);

        return CreatedAtAction(nameof(GetById), new { id = gato.Id }, gato);
    }

    // PUT /Mascota/{id} modificar una mascota existente
    [HttpPut("{id:int}")]
    public ActionResult<Mascota> Put(int id, Mascota datos)
    {
        Mascota? mascota = BuscarPorId(id);

        if (mascota == null)
        {
            return NotFound($"No existe una mascota con el Id {id}.");
        }

        mascota.Nombre = datos.Nombre;
        mascota.Edad = datos.Edad;

        if (mascota is Perro perro && datos is Perro perroNuevo)
        {
            perro.Raza = perroNuevo.Raza;
        }
        else if (mascota is Gato gato && datos is Gato gatoNuevo)
        {
            gato.Color = gatoNuevo.Color;
        }

        return Ok(mascota);
    }

    // DELETE /Mascota/{id} eliminar una mascota
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        Mascota? mascota = BuscarPorId(id);

        if (mascota == null)
        {
            return NotFound($"No existe una mascota con el Id {id}.");
        }

        Mascotas.Remove(mascota);

        return NoContent();
    }

    // GET /Mascota/mayores-a/{edad}  devolver todas las mascotas cuya edad sea mayor al valor recibido
    [HttpGet("mayores-a/{edad:int}")]
    public ActionResult<IEnumerable<Mascota>> GetMayoresA(int edad)
    {
        List<Mascota> resultado = [];

        foreach (Mascota mascota in Mascotas)
        {
            if (mascota.Edad > edad)
            {
                resultado.Add(mascota);
            }
        }

        return Ok(resultado);
    }

    // GET /Mascota/tipo/{tipo}  consultar las mascotas según su tipo
    [HttpGet("tipo/{tipo}")]
    public ActionResult<IEnumerable<Mascota>> GetPorTipo(string tipo)
    {
        List<Mascota> resultado = [];

        foreach (Mascota mascota in Mascotas)
        {
            if (tipo.ToLower() == "perro" && mascota is Perro)
            {
                resultado.Add(mascota);
            }
            else if (tipo.ToLower() == "gato" && mascota is Gato)
            {
                resultado.Add(mascota);
            }
        }

        if (tipo.ToLower() != "perro" && tipo.ToLower() != "gato")
        {
            return BadRequest("El tipo debe ser 'perro' o 'gato'.");
        }

        return Ok(resultado);
    }

    // si, lo hice asi por vago, no queria repetir lo mismo 3 veces.
    private static Mascota? BuscarPorId(int id)
    {
        foreach (Mascota mascota in Mascotas)
        {
            if (mascota.Id == id)
            {
                return mascota;
            }
        }

        return null;
    }
}
