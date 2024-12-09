using ActividadUT2.Domain.DTO;
using ActividadUT2.Domain.Generic;
using ActividadUT2.Functions;
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
    public ActionResult GetCats()
    {
        var response = _catService.Get();
        if (ExtensionFunctions.IsNullOrEmpty(response))
        {
            return NotFound();
        }
        return Ok(response);
    }

    [HttpGet("{id}")]
    public ActionResult GetCat([FromRoute] Guid id)
    {
        var response = _catService.Get(id);
        if (ExtensionFunctions.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }

    [HttpPost()]
    public ActionResult CreateCat([FromBody] CatDTO cat){
        var response = _catService.Create(cat);
        if (ExtensionFunctions.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }

    [HttpPut()]
    public ActionResult UpdateCat([FromBody] CatDTO cat){
        var response = _catService.Update(cat);
        if (ExtensionFunctions.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteCat([FromRoute] Guid id){
        var response = _catService.Delete(id);
        if (ExtensionFunctions.IsNullOrDefault(response))
        {
            return NotFound();
        }
        
        return Ok(response);
    }
}