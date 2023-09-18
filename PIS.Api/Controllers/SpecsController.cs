using Microsoft.AspNetCore.Mvc;
using PIS.Api.Models.Request.Spec;
using PIS.Core.DTOs;
using PIS.Core.DTOs.Spec;
using PIS.Core.Repositories.Specs;

namespace PIS.Api.Controllers;

[Route("api/specs")]
[ApiController]
public class SpecsController : ControllerBase
{
    private readonly ISpecsRepository _specsRepository;

    public SpecsController(ISpecsRepository specsRepository)
    {
        _specsRepository = specsRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateSpecAsync([FromBody] CreateSpecRequest request)
    {
        var dto = new SpecCreationDto(request.CdSb.Trim(), request.CdKp.Trim(), request.QtyKp);
        SpecDto spec = await _specsRepository.CreateSpecAsync(dto);
        return Ok(spec);
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> GetComponentsForDetailAsync([FromRoute] string id)
    {
        List<ComponentDto> components = await _specsRepository.GetComponentsForDetailAsync(id);
        return Ok(components);
    }

    [HttpGet("components/{id}")]
    public async Task<IActionResult> GetDetailsByComponentAsync([FromRoute] string id)
    {
        List<DetailDto> details = await _specsRepository.GetDetailsByComponentAsync(id);
        return Ok(details);
    }
}
