using Microsoft.AspNetCore.Mvc;
using PIS.Api.Models.Request.TypePr;
using PIS.Core.DTOs.TypePr;
using PIS.Core.Repositories.GLPRs;

namespace PIS.Api.Controllers;

[Route("api/type-prs")]
[ApiController]
public class TypePrsController : ControllerBase
{
    private readonly ITypePrsRepository _typePrsRepository;

    public TypePrsController(ITypePrsRepository typePrsRepository)
    {
        _typePrsRepository = typePrsRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTypePrAsync([FromBody] CreateTypePrRequest request)
    {
        var dto = new TypePrCreationDto(request.NmTp);
        TypePrDto spec = await _typePrsRepository.CreateTypePrAsync(dto);
        return Ok(spec);
    }
}
