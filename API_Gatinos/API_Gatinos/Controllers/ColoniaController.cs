using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Gatinos.Controllers;

[ApiController]
//[Route("[controller]")]
[Route("api")]
public class ColoniaController : ControllerBase
{
    private readonly IEntityService<Guid, ColoniaDto> _coloniaService;

    public ColoniaController(IEntityService<Guid, ColoniaDto> coloniaService)
    {
        _coloniaService = coloniaService;
    }

    [HttpGet("colonias")]
    public ActionResult GetColonias() => Ok("Devolviendo las colonias...");

    [HttpGet("colonias/{id}")]
    public ActionResult GetColonia([FromRoute] Guid id) =>
        Ok($"Devolviendo la colonia con id {id}...");

    [HttpPost("colonias")]
    public ActionResult CreateColonia([FromBody] ColoniaDto colonia) =>
        Ok(
            $"La colonia {colonia.Nombre} con un total de {colonia.Responsables.Count} responsables y {colonia.Gatos.Count} gatos ha sido creada con exito..."
        );

    [HttpPut("colonias")]
    public ActionResult UpdateColonia([FromBody] ColoniaDto colonia) =>
        Ok($"La colonia {colonia.Nombre} ha sido actualizada con exito...");

    [HttpDelete("colonias/{id}")]
    public ActionResult DeleteColonia([FromRoute] Guid id) =>
        Ok($"La colonia con id {id} ha sido borrada con exito...");
}
