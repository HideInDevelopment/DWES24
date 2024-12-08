using ActividadUT2.Domain.DTO;
using ActividadUT2.Domain.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ActividadUT2.Controllers;

[ApiController]
[Route("[controller]")]
public class CatController : ControllerBase
{
    private readonly IEntityService<Guid, CatDTO> _catService;
    
    public CatController(IEntityService<Guid, CatDTO> catService)
    {
        _catService = catService;
    }

    [HttpGet()]
    public ActionResult GetCats() => Ok(_catService.Get());

    [HttpGet("{id}")]
    public ActionResult GetCat([FromRoute] Guid id) => Ok(_catService.Get(id));

    [HttpPost()]
    public ActionResult CreateCat([FromBody] CatDTO cat) =>
        Ok(_catService.Create(cat));

    [HttpPut()]
    public ActionResult UpdateCat([FromBody] CatDTO cat) =>
        Ok(_catService.Update(cat));

    [HttpDelete("{id}")]
    public ActionResult DeleteCat([FromRoute] Guid id) =>
        Ok(_catService.Delete(id));
}