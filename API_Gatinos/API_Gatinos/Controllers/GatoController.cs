using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Gatinos.Controllers;

[ApiController]
[Route("[controller]")]
//[Route("api")]
public class GatoController : ControllerBase
{
    private readonly IEntityService<Guid, GatoDto> _gatoService;

    public GatoController(IEntityService<Guid, GatoDto> gatoService)
    {
        _gatoService = gatoService;
    }

    [HttpGet("gatos")]
    public ActionResult GetGatos() => Ok("Devolviendo los gatos...");

    [HttpGet("gatos/{id}")]
    public ActionResult GetGato([FromRoute] Guid id) => Ok($"Devolviendo el gato con id {id}...");

    [HttpPost("gatos")]
    public ActionResult CreateGato([FromBody] GatoDto gato) =>
        Ok(
            $"El gato {gato.Nombre} de raza {gato.Raza} y {gato.Edad} anios ha sido creado con exito..."
        );

    [HttpPut("gatos")]
    public ActionResult UpdateGato([FromBody] GatoDto gato) =>
        Ok($"El gato {gato.Nombre} ha sido actualizado con exito...");

    [HttpDelete("gatos/{id}")]
    public ActionResult DeleteGato([FromRoute] Guid id) =>
        Ok($"El gato con id {id} ha sido borrado con exito...");
}
