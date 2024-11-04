using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Gatinos.Controllers;

[ApiController]
[Route("[controller]")]
public class ColoniaController : ControllerBase
{
    private readonly IEntityService<Guid, ColoniaDTO> _coloniaService;

    public ColoniaController(IEntityService<Guid, ColoniaDTO> coloniaService)
    {
        _coloniaService = coloniaService;
    }

    [HttpGet()]
    public ActionResult GetColonias() => Ok("Devolviendo las colonias...");

    [HttpGet("{id}")]
    public ActionResult GetColonia([FromRoute] Guid id) =>
        Ok($"Devolviendo la colonia con id {id}...");

    [HttpPost()]
    public ActionResult CreateColonia([FromBody] ColoniaDTO colonia) =>
        Ok(
            $"La colonia {colonia.Nombre} con un total de {colonia.Colaboradores.Count} colaborador y {colonia.Gatos.Count} gatos ha sido creada con exito..."
        );

    [HttpPut()]
    public ActionResult UpdateColonia([FromBody] ColoniaDTO colonia) =>
        Ok($"La colonia {colonia.Nombre} ha sido actualizada con exito...");

    [HttpPatch("{id}")]
    public ActionResult SetLocation([FromRoute] Guid id, [FromBody] string ubication) =>
        Ok($"Actualizando la ubicacion de la colonia {id} a {ubication}...");

    [HttpDelete("{id}")]
    public ActionResult DeleteColonia([FromRoute] Guid id) =>
        Ok($"La colonia con id {id} ha sido borrada con exito...");
}
