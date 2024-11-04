using API_Gatinos.Models.DTOs;
using API_Gatinos.Models.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_Gatinos.Controllers;

[ApiController]
[Route("[controller]")]
public class ColaboradorController : ControllerBase
{
    private readonly IEntityService<Guid, ColaboradorDTO> _colaboradorService;

    public ColaboradorController(IEntityService<Guid, ColaboradorDTO> colaboradorService)
    {
        _colaboradorService = colaboradorService;
    }

    [HttpGet()]
    public ActionResult GetColaboradores() => Ok("Devolviendo los colaboradores...");

    [HttpGet("{id}")]
    public ActionResult GetColaborador([FromRoute] Guid id) =>
        Ok($"Devolviendo el colaborador con id {id}...");

    [HttpPost()]
    public ActionResult CreateColaborador([FromBody] ColaboradorDTO colaborador) =>
        Ok(
            $"El colaborador {colaborador.Nombre} con numero {colaborador.Telefono} a cargo de {colaborador.Colonias.Count} colonias ha sido creado con exito..."
        );

    [HttpPut()]
    public ActionResult UpdateColaborador([FromBody] ColaboradorDTO colaborador) =>
        Ok($"El colaborador {colaborador.Nombre} ha sido actualizado con exito...");

    [HttpDelete("{id}")]
    public ActionResult DeleteColaborador([FromRoute] Guid id) =>
        Ok($"El colaborador con id {id} ha sido borrado con exito...");
}
