using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Gatinos.Controllers;

[ApiController]
[Route("[controller]")]
public class GatoController : ControllerBase
{
    private readonly IEntityService<Guid, GatoDTO> _gatoService;

    public GatoController(IEntityService<Guid, GatoDTO> gatoService)
    {
        _gatoService = gatoService;
    }

    [HttpGet()]
    public ActionResult GetGatos() => Ok("Devolviendo los gatos...");

    [HttpGet("{id}")]
    public ActionResult GetGato([FromRoute] Guid id) => Ok($"Devolviendo el gato con id {id}...");

    [HttpPost()]
    public ActionResult CreateGato([FromBody] GatoDTO gato) =>
        Ok(
            $"El gato con nombre {gato.Nombre} de raza {gato.Raza} y {gato.Edad} anios ha sido creado con exito..."
        );

    [HttpPut()]
    public ActionResult UpdateGato([FromBody] GatoDTO gato) =>
        Ok($"El gato {gato.Nombre} ha sido actualizado con exito...");

    [HttpDelete("{id}")]
    public ActionResult DeleteGato([FromRoute] Guid id) =>
        Ok($"El gato con id {id} ha sido borrado con exito...");
}
