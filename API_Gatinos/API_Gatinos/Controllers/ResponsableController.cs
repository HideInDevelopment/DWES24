using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Gatinos.Controllers;

[ApiController]
//[Route("[controller]")]
[Route("api")]
public class ResponsableController : ControllerBase
{
    private readonly IEntityService<Guid, ResponsableDto> _responsableService;

    public ResponsableController(IEntityService<Guid, ResponsableDto> responsableService)
    {
        _responsableService = responsableService;
    }

    [HttpGet("responsables")]
    public ActionResult GetGatos() => Ok("Devolviendo los responsables...");

    [HttpGet("responsables/{id}")]
    public ActionResult GetGato([FromRoute] Guid id) =>
        Ok($"Devolviendo el responsable con id {id}...");

    [HttpPost("responsables")]
    public ActionResult CreateGato([FromBody] ResponsableDto responsable) =>
        Ok(
            $"El responsable {responsable.Nombre} con numero {responsable.Telefono} a cargo de {responsable.Colonias.Count} colonias ha sido creado con exito..."
        );

    [HttpPut("responsables")]
    public ActionResult UpdateGato([FromBody] ResponsableDto responsable) =>
        Ok($"El responsable {responsable.Nombre} ha sido actualizado con exito...");

    [HttpDelete("responsables/{id}")]
    public ActionResult DeleteGato([FromRoute] Guid id) =>
        Ok($"El responsable con id {id} ha sido borrado con exito...");
}
